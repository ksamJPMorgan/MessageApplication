using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Helpers
{
   public class ExceptionHelper
   {
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
   }
}
