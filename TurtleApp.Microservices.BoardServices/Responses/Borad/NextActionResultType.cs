using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.Microservices.BoardServices.Responses.Borad
{
    public enum NextActionResultType
    {
        SuccessMove,
        SuccessRotate,
        Win,
        Lost,
        Finished,
        Invalid,
        UnknownAction,
        Error,
    }
}
