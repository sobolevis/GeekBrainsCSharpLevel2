using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Asteroids
{
    class GameObjectException : _Exception
    {
        // До конца пока не понимаю зачем все это...
        // реализовал для тренировки
        public Exception GetBaseException()
        {
            return null;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
        public string Message => "Мое сообщение для исключения объекта!";
        public string StackTrace { get; }
        public string HelpLink { get; set; }
        public string Source { get; set; }
        public Exception InnerException { get; }
        public MethodBase TargetSite { get; }
    }
}
