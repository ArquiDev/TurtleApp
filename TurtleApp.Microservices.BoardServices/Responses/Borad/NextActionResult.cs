using TurtleApp.Crossccutting.Core.Models.Board;

namespace TurtleApp.Microservices.BoardServices.Responses.Borad
{
    public class NextActionResult
    {
        public Tableboard Board { get; set; }
        public NextActionResultType Type { get; set; }
    }
}
