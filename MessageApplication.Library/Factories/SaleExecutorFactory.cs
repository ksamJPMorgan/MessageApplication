using MessageApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Engines;

namespace MessageApplication.Library.Factories
{
   /// <summary>
   /// Not actual factory. Just mimics factory to return iSaleExecutors.
   /// </summary>
   public class SaleExecutorFactory
   {

      public static ISaleExecutor GetSaleExecutor(Message message)
      {
         // We could go with created objects here to avoid recreation or even singleton // static methods
         // but the constructor needed to be rewritten so it remained as is.
         switch(message.MessageType)
         {
            case MessageType.Single:
               return new SaleExecutorSimple(message.Sale);
            case MessageType.Multi:
               return new SaleExecutorMulti(message.Sale);
            case MessageType.Adjustment:
               return new SaleExecutorAdjustment(message.Sale, message.SaleAdjustment);
         }
         return null;
      }
   }
}
