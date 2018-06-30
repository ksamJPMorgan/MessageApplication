using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;

namespace MessageApplication.Library.Engines.Validators
{
   public class MessageValidatorMulti : MessageValidatorBase, IMessageValidator
   {
      public override bool MessageIsValid(Message message)
      {
         if (!base.MessageIsValid(message))
            return false;

         if (message.MessageType != MessageType.Multi)
         {
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedWarningMessage("The message type must be Multi.", message.MessageId));
            return false;
         }

         if (message.Sale.SaleOccurrences.GetValueOrDefault(1) <= 1)
         {
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedWarningMessage($"The sale occurrence must be bigger than 1 for a multi sale. Current value: { message.Sale.SaleOccurrences }", message.MessageId));
            return false;
         }
         return true;
      }
   }
}
