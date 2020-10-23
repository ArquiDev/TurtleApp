using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.Crossccutting.Core.Responses
{
    public class ResultResponse<T>
    {
        public T Result { get; set; }
        public virtual bool Success { get; protected set; }
    }
}
