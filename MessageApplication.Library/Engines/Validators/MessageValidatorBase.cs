using MessageApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApplication.Library.Core;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Core.Enums;

namespace MessageApplication.Library.Engines.Validators
{
   public class MessageValidatorBase : IMessageValidator
   {
      public virtual bool MessageIsValid(Message message)
      {
         if (message.Sale == null)
         {
            OutputLoggerHelper.WriteToOutput("* The incoming sale cannot be empty. *");
            return false;
         }

         if (message.Sale.SaleValue <= 0)
         {
            OutputLoggerHelper.WriteToOutput($"* The incoming sale value must be higher than 0. Current value { message.Sale.SaleValue } *");
            return false;
         }

         return true;
      }
   }
}
