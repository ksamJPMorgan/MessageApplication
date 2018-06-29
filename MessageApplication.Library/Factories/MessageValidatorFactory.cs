using MessageApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Engines.Validators;

namespace MessageApplication.Library.Factories
{
   /// <summary>
   /// Not actual factory. Just mimics factory in order to return appropriate IMessageValidators
   /// </summary>
   public sealed class MessageValidatorFactory
   {
      private static Dictionary<MessageType, IMessageValidator> validatorsDictionary = new Dictionary<MessageType, IMessageValidator>()
      {
         { MessageType.Single, new MessageValidatorSimple() },
         { MessageType.Multi, new MessageValidatorMulti() },
         { MessageType.Adjustment, new MessageValidatorAdjustment() }
      };

      public static bool MessageIsValid(Message message)
      {
         return validatorsDictionary[message.MessageType].MessageIsValid(message);
      }
   
   }
}
