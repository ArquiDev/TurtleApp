using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurtleApp.Crossccutting.Core.Exceptions;
using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Microservices.BoardServices.Controllers;
using TurtleApp.Microservices.BoardServices.Responses.Borad;

namespace TurtleApp.UI.TurtleApp.Helpers
{
    /// <summary>
    /// I use Helper pattern to easy do it, and not implemet a real restful services, so do a simple call, but on real could be a service proxxy project apart or just a class that manage the relation between the console application and the service. 
    /// </summary>
    static class BoardHelper
    {
        public static List<string> NextListActionResult(List<TurtleActionType> actions, Tableboard tableboard)
        {
            var serviceBoard = new BoardController();
            var actionsResult = serviceBoard.NextListActionResult(actions, tableboard);
            if (actionsResult.Success)
            {
                int sequential = 1;
                var result = actionsResult.Result.Select(r => $"Sequence {sequential++}: {GetActionResultText(r)}").ToList();
                if (actions.Count > sequential)
                    result.Add($"Sequence from {sequential} to {actions.Count}: {GetActionResultText(NextActionResultType.Finished)}");
                return result;
            }
            else
            {
                throw new MessageException("Something strange happen. Try again later please.");
            }
        }

        private static string GetActionResultText(NextActionResultType resultType) =>
            resultType switch
            {
                NextActionResultType.SuccessRotate => "The turtle successfully rotated.",
                NextActionResultType.SuccessMove => "The turtle successfully moved.",
                NextActionResultType.Win => "The turtle win!!!!",
                NextActionResultType.Lost => "Game over.",
                NextActionResultType.Invalid => "The turtle can't move outside of the borad.",
                NextActionResultType.Error => "Something strage happen.",
                NextActionResultType.Finished => "The game is over.",
                _ => "Unknown result.",
            };
    }
}
