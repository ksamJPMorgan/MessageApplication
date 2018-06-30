using MessageApplication.Library.Engines;
using MessageApplication.Library.Helpers;
using System;

namespace MessageApplication
{
   class Program
   {
      static void Main(string[] args)
      {

         // Clear output
         OutputLoggerHelper.ClearOutputFile();

         OutputLoggerHelper.WriteToOutput("*** Message Application Started ***");

         OutputLoggerHelper.WriteToOutput($"* Simulating data start: { DateTime.Now.ToString() } *");

         StartupMessageGenerator generator = new StartupMessageGenerator();
         generator.CreateMessages();

         OutputLoggerHelper.WriteToOutput($"* Simulating data finish: { DateTime.Now.ToString() } * ");

         // Invoke execution only if you manage to get Instance
         ApplicationExecutor.Instance?.StartExecution();

         OutputLoggerHelper.WriteToOutput("*** Message Application Finished ***");

         // Only display the output file if it exists and we did not set it to skip
         if (OutputLoggerHelper.OutputFileExists() && !OutputLoggerHelper.SkipOutputFile)
         {
            Console.WriteLine("Press Enter to open the output log txt file ");
            Console.ReadLine();
            OutputLoggerHelper.DisplayOutputFile();
         }

         Console.WriteLine("Press any key to exit application.");

         Console.ReadLine(); 
      }
   }
}
