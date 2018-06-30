using MessageApplication.Library.Core;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;
using System.Text;

namespace MessageApplication.Library.Engines.Validators
{
   public class MessageValidatorBase : IMessageValidator
   {
      public virtual bool MessageIsValid(Message message)
      {
         if (message.Sale == null)
         {
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedWarningMessage("The incoming sale cannot be empty", message.MessageId));
            return false;
         }

         if (message.Sale.SaleValue <= 0)
         {
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedWarningMessage($"The incoming sale value must be higher than 0. Current value { message.Sale.SaleValue }", message.MessageId));
            return false;
         }

         return true;
      }
   }
}
