﻿using MessageApplication.Library.Helpers;
using System;
using System.Collections.Generic;

namespace MessageApplication.Library.Core
{
   public sealed class DataManager
   {
      #region private fields
      private static List<Message> _pendingMessages = new List<Message>();
      private static List<Sale> _sales = new List<Sale>();
      private static List<Message> _completedMessages = new List<Message>();
      private static List<Message> _failedMessages = new List<Message>();
      private static List<SaleAdjustmentLog> _adjustments = new List<SaleAdjustmentLog>();
      #endregion

      #region IReadOnlyLists for iteration
      public static IReadOnlyList<Sale> GetReadOnlySaleList()
      {
         return _sales.AsReadOnly();
      }

      public static IReadOnlyCollection<Message> GetReadOnlyCompletedMessages()
      {
         return _completedMessages.AsReadOnly();
      }

      public static IReadOnlyCollection<SaleAdjustmentLog> GetReadOnlySaleAdjustments()
      {
         return _adjustments.AsReadOnly();
      }
      #endregion

      /// <summary>
      /// Adds a sale to the data manager.
      /// </summary>
      /// <param name="sale">The incoming sale</param>
      /// <returns>True if success, False if failed. In case of exception it will report the exception</returns>
      public static bool AddSale(Sale sale)
      {
         try
         {
            _sales.Add(sale);
            return true;
         }
         catch(Exception ex)
         {
            string initialMsg = "An exception occured trying to save the incoming sale";
            OutputLoggerHelper.WriteToOutput(ExceptionHelper.GetUnifiedExceptionMessage(initialMsg, ex));
            return false;
         }
      }

      /// <summary>
      /// Adds a completed message to an appropriate list
      /// </summary>
      /// <param name="message">The finished message</param>
      public static void AddCompletedMessage(Message message)
      {
         _completedMessages.Add(message);
      }

      /// <summary>
      /// Adds a failed message to an appropriate list
      /// </summary>
      /// <param name="message">The failed message</param>
      public static void AddFailedMessage(Message message)
      {
         _failedMessages.Add(message);
      }

      /// <summary>
      /// Adds a sale adjustment log to the history
      /// </summary>
      /// <param name="log"></param>
      public static void AddSaleAdjustment(SaleAdjustmentLog log)
      {
         _adjustments.Add(log);
      }

      /// <summary>
      /// Returns the next unprocessed message, if any.
      /// </summary>
      /// <returns>The next unprocessed message</returns>
      public static Message GetNextMessage()
      {
         // The HasPendingMessage should have protected us, but stil we check
         if (_pendingMessages.Count == 0)
            throw new Exception("There is no message to fetch.");

         // let`s avoid any issues. Copy the oldest, remove it from list and return
         // We are actually "mimicing" a Queue<T>
         Message newMessage = Message.Copy(_pendingMessages[0]);
         _pendingMessages.RemoveAt(0);
         return newMessage;
      }

      /// <summary>
      /// Checks if there are pending messages.
      /// </summary>
      /// <returns></returns>
      public static bool HasPendingMessages()
      {
         return _pendingMessages.Count > 0;
      }

      /// <summary>
      /// Adds a new message to the unprocessed list.
      /// </summary>
      /// <param name="message">The message to add</param>
      /// <returns>Returns an indicator of whether or not the message was added</returns>
      public static bool AddPendingMessage(Message message)
      {
         // if the message does not have a received date, give it when it gets added
         if (!message.ReceicedAt.HasValue)
            message.ReceicedAt = DateTime.Now;

         _pendingMessages.Add(message);
         return true;
      }
   }
}
