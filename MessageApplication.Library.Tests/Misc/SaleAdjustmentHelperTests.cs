using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Tests.Misc
{
   [TestFixture]
   public class SaleAdjustmentHelperTests
   {
      [Test]
      public void SaleAdjustmentHelper_When_InvalidValues_ThrowsException()
      {
         // Arrange

         // Act

         // Assert
         Assert.Throws(typeof(OverflowException), delegate { SaleAdjustmentHelper.CalculateSaleValue(AdjustmentType.Add, decimal.MaxValue, decimal.MaxValue); });
      }

      [Test]
      public void SaleAdjustmentHelper_When_12and15_Equals27()
      {
         // Arrange
         decimal returnedValue = 0;
         // Act
         returnedValue = SaleAdjustmentHelper.CalculateSaleValue(AdjustmentType.Add, 12, 15);

         // Assert
         Assert.AreEqual(27, returnedValue);
      }

      [Test]
      public void SaleAdjustmentHelper_When_12times15_Equals180()
      {
         // Arrange
         decimal returnedValue = 0;
         // Act
         returnedValue = SaleAdjustmentHelper.CalculateSaleValue(AdjustmentType.Multiply, 12, 15);

         // Assert
         Assert.AreEqual(180, returnedValue);
      }

      [Test]
      public void SaleAdjustmentHelper_When_12minus15_Equals0()
      {
         // Arrange
         decimal returnedValue = 0;
         // Act
         returnedValue = SaleAdjustmentHelper.CalculateSaleValue(AdjustmentType.Subtract, 15, 12);

         // Assert
         Assert.AreEqual(0, returnedValue);
      }
   }
}
