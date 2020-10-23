using System;
using System.Collections.Generic;
using System.Text;
using TurtleApp.Crossccutting.Core.Responses;
using TurtleApp.Microservices.BoardServices.Controllers;

namespace TurtleApp.Microservices.BoardServices.Responses.BoardValidation
{
    public class BoardValidationResult : ResultResponse<List<BoardValidationErrorType>>
    {
        public int MinWidth { get; set; } = BoardValidationController.MIN_CELL;
        public int MaxWidth { get; set; } = BoardValidationController.MAX_CELL;
        public int MinHeight { get; set; } = BoardValidationController.MIN_CELL;
        public int MaxHeight { get; set; } = BoardValidationController.MAX_CELL;

        public override bool Success
        {
            get => base.Success = !(Result?.Count > 0);
            protected set => base.Success = !(Result?.Count > 0); 
        }
    }
}
