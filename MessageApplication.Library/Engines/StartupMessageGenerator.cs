using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using System;

namespace MessageApplication.Library.Engines
{
   public class StartupMessageGenerator
   {
      /// <summary>
      /// Generates random combinations of messages
      /// </summary>
      public void CreateMessages()
      {
         Random r = new Random();
         for (int j = 0; j < 4; j++)
         {
            for (int i = 0; i < 10; i++)
            {
               Sale s = new Sale($"product { i }", decimal.Round(Convert.ToDecimal(r.NextDouble() * (20 - 0)), 2));
               Message m = new Message(s, MessageType.Single, null);

               DataManager.AddPendingMessage(m);
            }

            for (int i = 0; i < 10; i++)
            {
               Sale s = new Sale($"product { i }", decimal.Round(Convert.ToDecimal(r.NextDouble() * 1), 2), r.Next(10));
               Message m = new Message(s, MessageType.Multi, null);

               DataManager.AddPendingMessage(m);
            }

            AdjustmentType[] types = new AdjustmentType[] { AdjustmentType.Add, AdjustmentType.Multiply, AdjustmentType.Subtract };

            for (int i = 0; i < 10; i++)
            {
               Sale s = new Sale($"product { i }", decimal.Round(Convert.ToDecimal(r.NextDouble() * 1), 2));
               SaleAdjustment sa = new SaleAdjustment($"product { i }", decimal.Round(Convert.ToDecimal(r.NextDouble() * 10), 2), types[r.Next(3)]);
               Message m = new Message(s, MessageType.Adjustment, sa);

               DataManager.AddPendingMessage(m);
            }
         }
      }
   }
}
