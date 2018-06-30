namespace MessageApplication.Library.Core
{
   public class SaleExecutorBase
   {
      private Sale _sale;
      private SaleAdjustment _saleAdjustment;

      public Sale Sale
      {
         get
         {
            return _sale;
         }
      }

      public SaleAdjustment SaleAdjustment
      {
         get
         {
            return _saleAdjustment;
         }
      }

      public SaleExecutorBase(Sale sale, SaleAdjustment saleAdjustment = null)
      {
         _sale = sale;
         _saleAdjustment = saleAdjustment;
      }


   }
}
