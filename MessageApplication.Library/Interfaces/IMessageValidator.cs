using MessageApplication.Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication.Library.Interfaces
{
   interface IMessageValidator
   {
      bool MessageIsValid(Message message);
   }
}
