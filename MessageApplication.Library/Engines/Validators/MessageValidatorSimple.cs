using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;

namespace MessageApplication.Library.Engines.Validators
{
   public class MessageValidatorSimple : MessageValidatorBase, IMessageValidator
   {
      public override bool MessageIsValid(Message message)
      {

         if (!base.MessageIsValid(message))
            return false;

         if (message.MessageType != MessageType.Single)
         {
            OutputLoggerHelper.WriteToOutput("* The message type must be Single. *");
            return false;
         }

         return true;
      }
   }
}
