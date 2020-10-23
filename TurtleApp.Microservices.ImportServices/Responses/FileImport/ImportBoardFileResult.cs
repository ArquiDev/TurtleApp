using TurtleApp.Crossccutting.Core.Models.Board;
using TurtleApp.Crossccutting.Core.Responses;

namespace TurtleApp.Microservices.ImportServices.Responses.FileImport
{
    public class ImportBoardFileResult : ResultSuccessResponse<Tableboard>
    {
        public ImportFileResultErrorType ErrorType { get; set; }
    }
}
