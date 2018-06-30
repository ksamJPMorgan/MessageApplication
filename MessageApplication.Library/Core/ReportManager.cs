using MessageApplication.Library.Helpers;
using System;
using System.Linq;

namespace MessageApplication.Library.Core
{
   public sealed class ReportManager
   {
      /// <summary>
      /// Reports the sale adjustments made per adjustment type.
      /// </summary>
      public static void ReportSaleAdjustments()
      {
         OutputLoggerHelper.WriteToOutput(string.Empty);
         OutputLoggerHelper.WriteToOutput("*** Start: Reporting Sale Adjustments. ***");

         var groupedSalesByAdjustmentType = DataManager.GetReadOnlySaleAdjustments().GroupBy(s => s.AdjustmentType);

         foreach (var saleAdjustmentType in groupedSalesByAdjustmentType)
         {
            OutputLoggerHelper.WriteToOutput(Environment.NewLine + "* Sale Adjustment Type: " + saleAdjustmentType.Key.ToString());

            foreach (SaleAdjustmentLog sa in saleAdjustmentType)
            {
               OutputLoggerHelper.WriteToOutput(sa.ToString());
            }
         }
         OutputLoggerHelper.WriteToOutput("*** End: Reporting Sale Adjustments. ***");
         OutputLoggerHelper.WriteToOutput(string.Empty);
      }

      /// <summary>
      /// Reports the summary of sales per product
      /// </summary>
      public static void ReportSalesPerProduct()
      {
         OutputLoggerHelper.WriteToOutput(string.Empty);
         OutputLoggerHelper.WriteToOutput("*** Start: Reporting Sales per Product. ***");

         var groupedSalesByProduct = DataManager.GetReadOnlySaleList().GroupBy(s => s.Product);

         foreach (var sale in groupedSalesByProduct)
         {
            OutputLoggerHelper.WriteToOutput("* Product:\t\t " + sale.Key.ToString());
            OutputLoggerHelper.WriteToOutput("* Sale Nmbr:\t\t " + sale.Count().ToString());
            OutputLoggerHelper.WriteToOutput("* Total Value:\t\t " + sale.Sum(s => s.SaleValue).ToString("n2"));
            OutputLoggerHelper.WriteToOutput(string.Empty);
         }
         OutputLoggerHelper.WriteToOutput("*** End: Reporting Sales per Product. ***");
         OutputLoggerHelper.WriteToOutput(string.Empty);
      }

   }
}
