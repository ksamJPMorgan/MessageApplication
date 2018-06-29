using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Engines.Validators;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            OutputLoggerHelper.WriteToOutput("* The message type must be Multi. *");
            return false;
         }

         if (message.Sale.SaleOccurrences.GetValueOrDefault(1) <= 1)
         {
            OutputLoggerHelper.WriteToOutput("* The sale occurrence must be bigger than 1 for a multi sale. *");
            return false;
         }
         return true;
      }
   }
}
