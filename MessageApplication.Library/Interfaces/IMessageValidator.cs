using MessageApplication.Library.Core;

namespace MessageApplication.Library.Interfaces
{
   interface IMessageValidator
   {
      bool MessageIsValid(Message message);
   }
}
