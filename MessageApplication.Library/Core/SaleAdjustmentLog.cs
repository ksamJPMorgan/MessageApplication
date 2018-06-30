using System;
using System.Text;

namespace MessageApplication.Library.Core
{
   /// <summary>
   /// A class to describe a sale adjustment log
   /// </summary>
   public class SaleAdjustmentLog : SaleAdjustment
   {
      #region private fields
      private Guid _saleId;
      private decimal _previousValue;
      private decimal _newValue;
      private DateTime? _occuredAt;
      #endregion

      #region properties
      public Guid SaleId
      {
         get
         {
            return _saleId;
         }

         set
         {
            _saleId = value;
         }
      }
      public decimal PreviousValue
      {
         get
         {
            return _previousValue;
         }

         set
         {
            _previousValue = value;
         }
      }
      public decimal NewValue
      {
         get
         {
            return _newValue;
         }

         set
         {
            _newValue = value;
         }
      }
      /// <summary>
      /// If not overriten it will get by default the creation date of object creation
      /// </summary>
      public DateTime? OccuredAt
      {
         get
         {
            return _occuredAt;
         }

         set
         {
            _occuredAt = value;
         }
      }
      #endregion

      public SaleAdjustmentLog(Guid saleId, decimal previousValue, decimal newValue, DateTime? occuredDate = null, SaleAdjustment saleAdjustment = null)
      {
         AdjustmentType = saleAdjustment.AdjustmentType;
         AdjustmentValue = saleAdjustment.AdjustmentValue;
         Product = saleAdjustment.Product;

         _saleId = saleId;
         _previousValue = previousValue;
         _newValue = newValue;
         _occuredAt = occuredDate == null ? DateTime.Now : occuredDate;
      }

      public override string ToString()
      {
         StringBuilder sb = new StringBuilder();
         sb.AppendLine($"Sale Id:\t\t { _saleId.ToString()}");
         sb.AppendLine($"Product:\t\t { Product }");
         sb.AppendLine($"Sale value changed at: \t { _occuredAt.ToString()}");
         sb.AppendLine($"Previous value:\t\t { _previousValue.ToString("n2") }");
         sb.AppendLine($"New value:\t\t { _newValue.ToString("n2") }");

         return sb.ToString();
      }
   }
}
