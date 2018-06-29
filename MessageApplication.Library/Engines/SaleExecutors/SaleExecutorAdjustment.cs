using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Helpers;
using MessageApplication.Library.Interfaces;
using System;
using System.Linq;

namespace MessageApplication.Library.Engines
{
   public class SaleExecutorAdjustment : SaleExecutorBase, ISaleExecutor
   {
      public SaleExecutorAdjustment(Sale sale, SaleAdjustment saleAdjustment) : base(sale, saleAdjustment) { }

      public bool ExecuteSale()
      {
         decimal adjValue = SaleAdjustment.AdjustmentValue;
         AdjustmentType adjType = SaleAdjustment.AdjustmentType;

         // Add the sale first
         if (!DataManager.AddSale(Sale))
            return false;

         // fetch only sales relevent to the adjustment product
         var productSales = DataManager.GetReadOnlySaleList().Where(s => s.Product.Equals(SaleAdjustment.Product, StringComparison.OrdinalIgnoreCase)).ToList();

         // and adjust them. for each adjusted there will be a sale adjustment history log
         productSales.ForEach(s =>
         {
            // create the adjustment object to log
            SaleAdjustmentLog adjLog = new SaleAdjustmentLog(s.SaleId, s.SaleValue, 0, null, SaleAdjustment);
            // change the sale value
            s.SaleValue = SaleAdjustmentHelper.CalculateSaleValue(adjType, adjValue, s.SaleValue);
            // and log the adjustment
            adjLog.NewValue = s.SaleValue;
            adjLog.OccuredAt = DateTime.Now;
            DataManager.AddSaleAdjustment(adjLog);
         });

         return true;
      }
   }
}
