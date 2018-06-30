using MessageApplication.Library.Core.Enums;

namespace MessageApplication.Library.Core
{
   public class SaleAdjustment
   {
      #region private fields

      private string _product;
      private decimal _adjustmentValue;
      private AdjustmentType _adjustmentType;
      #endregion

      #region  properties
      public string Product
      {
         get
         {
            return _product;
         }

         set
         {
            _product = value;
         }
      }
      public decimal AdjustmentValue
      {
         get
         {
            return _adjustmentValue;
         }

         set
         {
            _adjustmentValue = value;
         }
      }
      public AdjustmentType AdjustmentType
      {
         get
         {
            return _adjustmentType;
         }

         set
         {
            _adjustmentType = value;
         }
      }
      #endregion

      public SaleAdjustment() { }

      public SaleAdjustment(string product, decimal adjustmentValue, AdjustmentType adjType)
      {
         _product = product;
         _adjustmentValue = adjustmentValue;
         _adjustmentType = adjType;
      }

      public override string ToString()
      {
         return base.ToString();
      }
   }
}
