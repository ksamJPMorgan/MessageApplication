using MessageApplication.Library.Core;
using MessageApplication.Library.Interfaces;

namespace MessageApplication.Library.Engines
{
   public class SaleExecutorMulti : SaleExecutorBase, ISaleExecutor
   {
      public SaleExecutorMulti(Sale sale, SaleAdjustment saleAdjustment = null) : base(sale, saleAdjustment) { }

      public bool ExecuteSale()
      {
         // Add the first sale
         if (!DataManager.AddSale(Sale))
            return false;

         // And create a new incoming sale for all occurrences in order to create sale ids;
         // we will keep the parent guid as reference
         for (int i = 1; i < Sale.SaleOccurrences; i++)
         {
            var newSale = new Sale(Sale.Product, Sale.SaleValue, Sale.SaleOccurrences, Sale.ParentSaleId = Sale.SaleId);
            DataManager.AddSale(newSale);
         }

         return true;
      }
   }
}
