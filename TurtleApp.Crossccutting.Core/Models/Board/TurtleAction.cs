using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.Crossccutting.Core.Models.Board
{
    public struct TurtleAction
    {
        public const string ROTATE = "R";
        public const string MOVE = "M";
        public const string UNKNOWN = "UNKNOWN";
        public TurtleActionType Action { get; set; }
        public override string ToString() => Action switch
        {
            TurtleActionType.Rotate => ROTATE,
            TurtleActionType.Move => ROTATE,
            _ => UNKNOWN,
        };
        public static explicit operator TurtleAction(String value) => value switch
        {
            ROTATE => new TurtleAction { Action = TurtleActionType.Rotate },
            MOVE => new TurtleAction { Action = TurtleActionType.Move },
            _ => new TurtleAction { Action = TurtleActionType.UNKNOWN },
        };
        public static explicit operator String(TurtleAction value) => value.ToString();
    }
}
