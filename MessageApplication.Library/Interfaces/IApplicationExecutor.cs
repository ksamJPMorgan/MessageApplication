using MessageApplication.Library.Core;

namespace MessageApplication.Library.Interfaces
{
   public interface IApplicationExecutor
   {
      void StartExecution();
      void ProcessMessage(Message message);
   }
}
