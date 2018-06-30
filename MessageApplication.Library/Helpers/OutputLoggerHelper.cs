using System;
using System.Diagnostics;
using System.IO;

namespace MessageApplication.Library.Helpers
{
   /// <summary>
   /// Helper class for better output
   /// </summary>
   public class OutputLoggerHelper
   {
      public const string OUTPUT_FILE_NAME = "outputLog.txt";

      /// <summary>
      /// If set to true, the application will not output to a file. Only on console
      /// </summary>
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
            try
            {
               using (StreamWriter file = new StreamWriter(OUTPUT_FILE_NAME, true))
               {
                  file.WriteLine(s);
               }
            }
            catch(Exception ex)
            {
               // if a problem occurs with the I/O, reset the flag and output only to Console.
               SkipOutputFile = true;
               Console.WriteLine(ExceptionHelper.GetUnifiedExceptionMessage("There was a problem trying to write to the output file. Output set to Console only.", ex));
            }
         }
      }

      /// <summary>
      /// Clears existing output file
      /// </summary>
      public static void ClearOutputFile()
      {
         if (OutputFileExists())
            File.Delete(OUTPUT_FILE_NAME);
      }

      /// <summary>
      /// Checks whether the output file exists.
      /// </summary>
      /// <returns></returns>
      public static bool OutputFileExists()
      {
         return File.Exists(OUTPUT_FILE_NAME);
      }

      /// <summary>
      /// Opens the output file for display/edit
      /// </summary>
      public static void DisplayOutputFile()
      {
         Process.Start(OUTPUT_FILE_NAME);
      }
   }
}
