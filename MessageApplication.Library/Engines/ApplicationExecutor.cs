using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Factories;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;
using System;

namespace MessageApplication.Library.Engines
{
   public class ApplicationExecutor : IApplicationExecutor
   {
      #region private fields
      private const int REPORT_SALES_THRESHOLD = 10;
      private const int REPORT_ADJUSTMENTS_THRESHOLD = 50;

      private ApplicationStatus appStatus;


      private static ApplicationExecutor _executor;
      #endregion

      #region constructor
      private ApplicationExecutor() { }
      #endregion

      public static ApplicationExecutor Instance
      {
         get
         {
            if (_executor == null)
               _executor = new ApplicationExecutor();

            return _executor;
         }
      }

      public void StartExecution()
      {
         appStatus = ApplicationStatus.Running;
         while(DataManager.HasPendingMessages())
         {
            ProcessMessage(DataManager.GetNextMessage());
         }
      }

      public void ProcessMessage(Message message)
      {
         try
         {
            // Validate message
            bool messageValidated = MessageValidatorFactory.MessageIsValid(message);

            if (!messageValidated)
            {
               DataManager.AddFailedMessage(message);
               return;
            }

            // Get appropriate sale executor and invoke him
            bool saleCompleted = SaleExecutorFactory.GetSaleExecutor(message).ExecuteSale();

            // Mark as processed
            message.ProcessedAt = DateTime.Now;

            if (!saleCompleted)
            {
               // Code duplication. TODO: Refactor to method and slight logic change
               DataManager.AddFailedMessage(message);
               return;
            }

            DataManager.AddCompletedMessage(message);

            // check messages and evaluate if we need to report
            if (DataManager.GetReadOnlyCompletedMessages().Count % REPORT_SALES_THRESHOLD == 0)
               ReportManager.ReportSalesPerProduct();

            // Here we should freeze application until finished
            if (DataManager.GetReadOnlyCompletedMessages().Count % REPORT_ADJUSTMENTS_THRESHOLD == 0)
            {
               appStatus = ApplicationStatus.Paused;
               OutputLoggerHelper.WriteToOutput("** Application paused. Queueing all incoming messages.");

               ReportManager.ReportSaleAdjustments();

               appStatus = ApplicationStatus.Running;
               OutputLoggerHelper.WriteToOutput("** Application resumed. Queueing all incoming messages.");
            }


         }
         catch(Exception ex)
         {
            DataManager.AddFailedMessage(message);
            string initialMsg = "An error occured while processing the message";
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedExceptionMessage(initialMsg, ex));
         }
      }
   }
}
