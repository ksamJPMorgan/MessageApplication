using MessageApplication.Library.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Helpers
{
   /// <summary>
   /// Helper class for the calculations of sale adjustments
   /// </summary>
   public class SaleAdjustmentHelper
   {
      public static decimal CalculateSaleValue(AdjustmentType type, decimal adjValue, decimal originalValue)
      {
         decimal retVal = 0;

         try
         {
            switch (type)
            {
               case AdjustmentType.Add:
                  retVal = originalValue + adjValue;
                  retVal = (retVal > Decimal.MaxValue ? Decimal.MaxValue : retVal);
                  break;
               case AdjustmentType.Multiply:
                  retVal = originalValue * adjValue;
                  retVal = (retVal > Decimal.MaxValue ? Decimal.MaxValue : retVal);
                  break;
               case AdjustmentType.Subtract:
                  decimal subtractedValue = originalValue - adjValue;
                  retVal = subtractedValue < 0 ? 0 : subtractedValue;
                  break;
            }
         }
         catch(OverflowException ex)
         {
            string msg = "An exception occured trying to apply the adjustment action";
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedExceptionMessage(msg, ex));

            // we will throw this error, this is serious. this will trigger the skip of the message
            throw ex;
         }

         return retVal;
      }
   }
}
