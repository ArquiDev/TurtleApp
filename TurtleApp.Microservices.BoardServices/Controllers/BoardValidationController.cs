using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Microservices.BoardServices.Responses.BoardValidation;

namespace TurtleApp.Microservices.BoardServices.Controllers
{
    public class BoardValidationController
    {
        public const int MIN_CELL = 2;
        public const int MAX_CELL = 1000;

        public BoardValidationResult ValidateBoard(Tableboard board)
        {
            var maxX = Math.Min(MAX_CELL, Math.Max(0, board.Size.Width - 1));
            var maxY = Math.Min(MAX_CELL, Math.Max(0, board.Size.Height - 1));
            Func<Point, bool> isOutsideBoard = point =>
                point.X < 0 ||
                point.X > maxX ||
                point.Y < 0 ||
                point.Y > maxY;
            var result = new BoardValidationResult { Result = new List<BoardValidationErrorType>() };
            if (board.Size.Width < MIN_CELL || board.Size.Width > MAX_CELL)
                result.Result.Add(BoardValidationErrorType.WrongWidth);
            if (board.Size.Height < MIN_CELL || board.Size.Height > MAX_CELL)
                result.Result.Add(BoardValidationErrorType.WrongHeight);
            if (isOutsideBoard(board.Exit))
                result.Result.Add(BoardValidationErrorType.WrongExit);
            if (isOutsideBoard(board.Turtle.Position))
                result.Result.Add(BoardValidationErrorType.WrongTurtlePosition);

            return result;
        }
    }
}
