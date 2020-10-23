using System.Collections.Generic;
using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Crossccutting.Core.Responses;

namespace TurtleApp.Microservices.ImportServices.Responses.FileImport
{
    public class ImportActionFileResult : ResultSuccessResponse<List<TurtleActionType>>
    {
        public ImportFileResultErrorType ErrorType { get; set; }
    }
}
