using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Crossccutting.Core.Responses;

namespace TurtleApp.Microservices.BoardServices.Responses.Borad
{
    public class NextListActionResult : ResultResponse<List<NextActionResultType>>
    {
        public Tableboard Board { get; set; }
        public override bool Success
        {
            get => base.Success = Result?.All(r => r != NextActionResultType.Error) ?? false;
            protected set => base.Success = Result?.All(r => r != NextActionResultType.Error) ?? false;
        }
    }
}
