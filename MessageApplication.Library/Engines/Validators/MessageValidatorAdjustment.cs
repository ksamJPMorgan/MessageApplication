using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;
using System;

namespace MessageApplication.Library.Engines.Validators
{
   public class MessageValidatorAdjustment : MessageValidatorBase, IMessageValidator
   {

      public override bool MessageIsValid(Message message)
      {
         if (!base.MessageIsValid(message))
            return false;

         if (message.MessageType != MessageType.Adjustment)
         {
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedWarningMessage("The message type must be Adjustment.", message.MessageId));
            return false;
         }

         if (message.SaleAdjustment == null)
         {
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedWarningMessage("The sale adjustment cannot be empty for sale adjustment message.", message.MessageId));
            return false;
         }

         if (message.SaleAdjustment.AdjustmentValue < 1 || message.SaleAdjustment.AdjustmentValue == Decimal.MinValue)
         {
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedWarningMessage($"The sale adjustment value must be at least { new decimal(1).ToString("n2") } for sale adjustment message. Current sale adjustment: { message.SaleAdjustment.AdjustmentValue.ToString() }", message.MessageId));
            return false;
         }

         return true;
      }
   }
}
