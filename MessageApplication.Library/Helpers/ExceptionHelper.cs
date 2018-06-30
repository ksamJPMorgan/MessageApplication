using System;
using System.Text;

namespace MessageApplication.Library.Helpers
{
   public class ExceptionHelper
   {
      /// <summary>
      /// Get a unified style for exception messages
      /// </summary>
      /// <param name="header">The message to use a message header</param>
      /// <param name="ex">The occured exception</param>
      /// <returns></returns>
      public static string GetUnifiedExceptionMessage(string header, Exception ex)
      {
         string initialMsg = $" !!! { header } !!!";
         StringBuilder sb = new StringBuilder();
         sb.AppendLine(initialMsg);
         sb.AppendLine($" Exception message:\t\t { ex.Message }");
         sb.AppendLine($" Exception details:\t\t { ex.ToString() }");
         sb.AppendLine(new String('*', initialMsg.Length));
         return sb.ToString();
      }

      /// <summary>
      /// Get a unified style for warning during message validations
      /// </summary>
      /// <param name="warningMessage"></param>
      /// <param name="ex"></param>
      /// <returns></returns>
      public static string GetUnifiedWarningMessage(string warningMessage, Guid messageId)
      {
         string initialMsg = "*** Message Validation Warning ***";
         StringBuilder sb = new StringBuilder();
         sb.AppendLine(initialMsg);
         sb.AppendLine($"* Message:\t { messageId }");
         sb.AppendLine($"* { warningMessage } *");
         sb.AppendLine(new String('*', initialMsg.Length));        
         return sb.ToString();
      }
   }
}
