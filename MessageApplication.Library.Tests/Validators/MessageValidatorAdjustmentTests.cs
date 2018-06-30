using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Engines;
using MessageApplication.Library.Engines.Validators;
using MessageApplication.Library.Helpers;
using NUnit.Framework;
using System;

namespace MessageApplication.Library.Tests.Validators
{
   [TestFixture]
   public class MessageValidatorAdjustmentTests
   {
      [Test]
      public void Adj_When_SaleNull_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorAdjustment v = new MessageValidatorAdjustment();
         Message m = new Message(null, MessageType.Adjustment);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Adj_When_TypeIsIncorrect_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorAdjustment v = new MessageValidatorAdjustment();
         Message m = new Message(new Sale(), MessageType.Single);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Adj_When_SaleValueIncorrect_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorAdjustment v = new MessageValidatorAdjustment();
         Message m = new Message(new Sale("product", Decimal.MinValue), MessageType.Adjustment);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Adj_When_SaleAdjustmentNull_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorAdjustment v = new MessageValidatorAdjustment();
         Sale s = new Sale("product", 1.5m);
         Message m = new Message(s, MessageType.Adjustment);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Adj_When_AdjustmentValueIsWrong_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorAdjustment v = new MessageValidatorAdjustment();
         Sale s = new Sale("product", 2.5m);
         SaleAdjustment sa = new SaleAdjustment("product", Decimal.MinValue, AdjustmentType.Add);
         Message m = new Message(s, MessageType.Adjustment, sa);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);
         bool isSaleSaved = new SaleExecutorAdjustment(s, sa).ExecuteSale();

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Adj_When_TypeAndSaleOk_SaveSale()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorAdjustment v = new MessageValidatorAdjustment();
         Sale s = new Sale("product", 2.5m, 6);
         SaleAdjustment sa = new SaleAdjustment("product", 4, AdjustmentType.Add);
         Message m = new Message(s, MessageType.Adjustment, sa);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);
         bool isSaleSaved = new SaleExecutorAdjustment(s, sa).ExecuteSale();

         // Assert
         Assert.AreEqual(true, isMeesageValid);
         Assert.AreEqual(true, isSaleSaved);

         Console.WriteLine($"Sales entered: { DataManager.GetReadOnlySaleList().Count }, Sale adjustments performed { DataManager.GetReadOnlySaleAdjustments().Count }");
      }
   }
}
