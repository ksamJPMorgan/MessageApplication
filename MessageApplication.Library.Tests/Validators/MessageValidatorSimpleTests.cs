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
   public class MessageValidatorSimpleTests
   {
      [Test]
      public void Simple_When_SaleNull_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorSimple v = new MessageValidatorSimple();
         Message m = new Message(null, MessageType.Single);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Simple_When_TypeIsIncorrect_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorSimple v = new MessageValidatorSimple();
         Message m = new Message(new Sale(), MessageType.Multi);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Simple_When_SaleValueIncorrect_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorSimple v = new MessageValidatorSimple();
         Message m = new Message(new Sale("product", 0), MessageType.Single);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Simple_When_TypeAndSaleOk_SaveSale()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorSimple v = new MessageValidatorSimple();
         Sale s = new Sale("product", 1.5m);
         Message m = new Message(s, MessageType.Single);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);
         bool isSaleSaved = new SaleExecutorSimple(s).ExecuteSale();

         // Assert
         Assert.AreEqual(true, isMeesageValid);
         Assert.AreEqual(true, isSaleSaved);

         Console.WriteLine(DataManager.GetReadOnlySaleList().Count);
      }
   }
}
