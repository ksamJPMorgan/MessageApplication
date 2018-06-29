using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Helpers
{
   /// <summary>
   /// Helper class for better output
   /// </summary>
   public class OutputLoggerHelper
   {
      public const string OUTPUT_FILE_NAME = "outputLog.txt";
      public static bool SkipOutputFile = false;
      /// <summary>
      /// Writes in both console and output file.
      /// </summary>
      /// <param name="s"></param>
      public static void WriteToOutput(string s)
      {
         
         Console.WriteLine(s);
         if (!SkipOutputFile)
         {
            using (StreamWriter file = new StreamWriter(OUTPUT_FILE_NAME, true))
            {
               file.WriteLine(s);
            }
         }
      }

      /// <summary>
      /// Clears existing output file
      /// </summary>
      public static void ClearOutputFile()
      {
         if (File.Exists(OUTPUT_FILE_NAME))
            File.Delete(OUTPUT_FILE_NAME);
      }
   }
}
