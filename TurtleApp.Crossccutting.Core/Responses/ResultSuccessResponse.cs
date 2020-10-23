using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.Crossccutting.Core.Responses
{
    public class ResultSuccessResponse<T> : ResultResponse<T>
    {
        public override bool Success 
        { 
            get => base.Success = Result != null; 
            protected set => base.Success = Result != null;
        }
    }
}
