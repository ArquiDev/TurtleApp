using System;
using System.Collections.Generic;
using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Microservices.BoardServices.Responses.Borad;

namespace TurtleApp.Microservices.BoardServices.Controllers
{
    public class BoardController
    {
        public NextListActionResult NextListActionResult(List<TurtleActionType> actions, Tableboard tableboard)
        {
            var result = new NextListActionResult { Result = new List<NextActionResultType>(), Board = tableboard };
            var actionsQueue = new Queue<TurtleActionType>(actions);
            while (!tableboard.Finished && actionsQueue.TryDequeue(out TurtleActionType action))
            {
                result.Result.Add(NextActionResult(action, tableboard).Type);
            }
            return result;
        }
        public NextActionResult NextActionResult(TurtleActionType action, Tableboard tableboard)
        {
            var result = new NextActionResult { Board = tableboard };
            if (tableboard.Won || tableboard.Lose)
            {
                result.Type = NextActionResultType.Finished;
            }
            else
            {
                try
                {
                    switch (action)
                    {
                        case TurtleActionType.Rotate:
                            tableboard.RotateTurtle();
                            result.Type = NextActionResultType.SuccessRotate;
                            break;
                        case TurtleActionType.Move:
                            if (tableboard.CanTurtleMove())
                            {
                                tableboard.MoveTurtle();
                                result.Type = tableboard.Won ?
                                                    NextActionResultType.Win :
                                                    tableboard.Lose ?
                                                            NextActionResultType.Lost :
                                                            NextActionResultType.SuccessMove;
                            }
                            else
                            {
                                result.Type = NextActionResultType.Invalid;
                            }
                            break;
                        default:
                            result.Type = NextActionResultType.UnknownAction;
                            break;
                    }
                }
                catch
                {
                    result.Type = NextActionResultType.Error;
                }
            }
            return result;
        }
    }
}
