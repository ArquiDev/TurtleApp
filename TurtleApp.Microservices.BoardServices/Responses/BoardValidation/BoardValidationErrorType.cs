using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.Microservices.BoardServices.Responses.BoardValidation
{
    public enum BoardValidationErrorType
    {
        WrongWidth,
        WrongHeight,
        WrongExit,
        WrongTurtlePosition
    }
}
