using MessageApplication.Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Interfaces
{
   public interface IApplicationExecutor
   {
      void StartExecution();
      void ProcessMessage(Message message);
   }
}
