using MessageApplication.Library.Core;
using MessageApplication.Library.Core.Enums;
using MessageApplication.Library.Engines;
using MessageApplication.Library.Interfaces;

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
         // but the constructor needed to be rewritten so it remained as is. It is worth checking the memory consumption in
         // more real life scenarios and the GC correspondance.
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
