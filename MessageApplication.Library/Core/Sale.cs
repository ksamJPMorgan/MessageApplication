using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Core
{
   public class Sale
   {
      #region private fields
      private Guid _saleId;
      private string _product;
      private decimal _saleValue;
      private int? _saleOccurrences;
      private Guid? _parentSaleId;
      #endregion

      #region properties
      public Guid SaleId
      {
         get
         {
            return _saleId;
         }
      }

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

      public decimal SaleValue
      {
         get
         {
            return _saleValue;
         }

         set
         {
            _saleValue = value;
         }
      }

      public int? SaleOccurrences
      {
         get
         {
            return _saleOccurrences;
         }

         set
         {
            _saleOccurrences = value;
         }
      }

      public Guid? ParentSaleId
      {
         get
         {
            return _parentSaleId;
         }

         set
         {
            _parentSaleId = value;
         }
      }
      #endregion

      public Sale()
      {
         _saleId = Guid.NewGuid();
      }

      public Sale(string product, decimal saleValue, int? saleOccurrences = null, Guid? parentSaleId = null) : this()
      {
         _product = product;
         _saleValue = saleValue;
         _saleOccurrences = saleOccurrences;
         _parentSaleId = parentSaleId;
      }
   }
}
