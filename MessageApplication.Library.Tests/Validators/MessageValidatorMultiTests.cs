using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Engines;
using MessageApplication.Library.Engines.Validators;
using MessageApplication.Library.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Tests.Validators
{
   [TestFixture]
   public class MessageValidatorMultiTests
   {
      [Test]
      public void Multi_When_SaleNull_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorMulti v = new MessageValidatorMulti();
         Message m = new Message(null, MessageType.Multi);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Multi_When_TypeIsIncorrect_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorMulti v = new MessageValidatorMulti();
         Message m = new Message(new Sale(), MessageType.Adjustment);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Multi_When_SaleValueIsIncorrect_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorMulti v = new MessageValidatorMulti();
         Message m = new Message(new Sale("product", -1), MessageType.Multi);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Multi_When_SaleOccurenceLessThan2_PrintsWarning_And_ReturnsFalse()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorMulti v = new MessageValidatorMulti();
         Sale s = new Sale("product", 1.5m, 1);
         Message m = new Message(s, MessageType.Multi);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);

         // Assert
         Assert.AreEqual(false, isMeesageValid);
      }

      [Test]
      public void Multi_When_TypeAndSaleOk_SaveSale()
      {
         // Arrange
         OutputLoggerHelper.SkipOutputFile = true;
         MessageValidatorMulti v = new MessageValidatorMulti();
         int occurrence = 6;
         Sale s = new Sale("product", 2.5m, 6);
         Message m = new Message(s, MessageType.Multi);

         // Act

         bool isMeesageValid = v.MessageIsValid(m);
         bool isSaleSaved = new SaleExecutorMulti(s).ExecuteSale();

         // Assert
         Assert.AreEqual(true, isMeesageValid);
         Assert.AreEqual(true, isSaleSaved);

         Console.WriteLine($"Occurences { occurrence }. Sales entered: { DataManager.GetReadOnlySaleList().Count }");
      }
   }
}
