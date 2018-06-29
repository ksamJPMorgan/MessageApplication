using MessageApplication.Library.Core;
using MessageApplication.Library.Interfaces;

namespace MessageApplication.Library.Engines
{
   public class SaleExecutorSimple : SaleExecutorBase, ISaleExecutor
   {
      public SaleExecutorSimple(Sale sale, SaleAdjustment saleAdjustment = null) : base(sale, saleAdjustment) { }

      public bool ExecuteSale()
      {
         return DataManager.AddSale(Sale);
      }
   }
}
