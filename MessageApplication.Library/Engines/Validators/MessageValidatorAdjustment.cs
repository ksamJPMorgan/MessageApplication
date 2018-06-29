using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            OutputLoggerHelper.WriteToOutput("* The message type must be Adjustment. *");
            return false;
         }

         if (message.SaleAdjustment == null)
         {
            OutputLoggerHelper.WriteToOutput("* The sale adjustment cannot be empty for sale adjustment message. *");
            return false;
         }

         if (message.SaleAdjustment.AdjustmentValue < 1 || message.SaleAdjustment.AdjustmentValue == Decimal.MinValue)
         {
            OutputLoggerHelper.WriteToOutput($"* The sale adjustment value must be at least { new decimal(1).ToString("n2") } for sale adjustment message. Current sale adjustment: { message.SaleAdjustment.AdjustmentValue.ToString() }*");
            return false;
         }

         return true;
      }
   }
}
