using MessageApplication.Library.Core.Enums;
using System;
using System.Text;

namespace MessageApplication.Library.Core
{
   public sealed class Message
   {
      #region private fields
      private Guid _messageId;
      private MessageType _messageType;
      private Sale _sale;
      private SaleAdjustment _saleAdjustment;
      private DateTime? _receicedAt;
      private DateTime? _processedAt;
      #endregion

      #region properties
      public Sale Sale
      {
         get
         {
            return _sale;
         }

         set
         {
            _sale = value;
         }
      }

      public SaleAdjustment SaleAdjustment
      {
         get
         {
            return _saleAdjustment;
         }

         set
         {
            _saleAdjustment = value;
         }
      }

      public DateTime? ReceicedAt
      {
         get
         {
            return _receicedAt;
         }

         set
         {
            _receicedAt = value;
         }
      }

      public DateTime? ProcessedAt
      {
         get
         {
            return _processedAt;
         }

         set
         {
            _processedAt = value;
         }
      }

      /// <summary>
      /// Getter only. This is privately managed and given to any new message
      /// during it`s creation
      /// </summary>
      public Guid MessageId
      {
         get
         {
            return _messageId;
         }
      }

      public MessageType MessageType
      {
         get
         {
            return _messageType;
         }
      }
      #endregion

      #region Constructors
      public Message()
      {
         _messageId = Guid.NewGuid();
      }

      public Message(Sale sale, MessageType messageType, SaleAdjustment saleAdjustment = null, DateTime? receivedAt = null, DateTime? processedAt = null) : this()
      {
         _sale = sale;
         _messageType = messageType;
         _saleAdjustment = saleAdjustment;
         _receicedAt = receivedAt;
         _processedAt = processedAt;
      }
      #endregion

      public override string ToString()
      {
         StringBuilder sb = new StringBuilder();
         sb.AppendLine("*** Message Info ***");
         sb.AppendLine($" Message id:\t\t { _messageId }");
         sb.AppendLine($" Sale id:\t\t { _sale.SaleId }");
         sb.AppendLine($" Received at:\t\t { _receicedAt.ToString() }");
         sb.AppendLine($" Processed at:\t\t { _processedAt.ToString() }");
         sb.AppendLine(new String('*', 20));
         return sb.ToString();
      }

      /// <summary>
      /// Custom copy operation to ensure nothing goes wrong with the references
      /// </summary>
      /// <param name="messageToCopy"></param>
      /// <returns></returns>
      public static Message Copy(Message messageToCopy)
      {
         return new Message(messageToCopy.Sale, messageToCopy.MessageType, messageToCopy.SaleAdjustment, messageToCopy.ReceicedAt, messageToCopy.ProcessedAt);
      }
   }
}
