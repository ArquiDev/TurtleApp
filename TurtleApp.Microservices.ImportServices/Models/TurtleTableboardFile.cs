using System;
using System.Drawing;

namespace TurtleApp.Microservices.ImportServices.Models
{
    public class TurtleTableboardFile
    {
        public Size Size { get; set; }
        public Point Exit { get; set; }
        public Point[] Mines { get; set; }
        public Point TurtlePosition { get; set; }
        public string TurtleDirection { get; set; }
    }
}
