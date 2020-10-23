using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.Crossccutting.Core.Exceptions
{
    public class MessageException : Exception
    {
        public MessageException(string message) : base(message) { }
        public MessageException(string message, Exception innerException) : base(message, innerException) { }
    }
}
