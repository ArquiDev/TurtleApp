using System.Collections.Generic;
using System.Drawing;

namespace TurtleApp.Crossccutting.Core.Models.Board
{
    public class Tableboard
    {
        public Size Size { get; set; }
        public Point Exit { get; set; }
        public HashSet<Point> Mines { get; set; }

        private Turtle turtle;
        public Turtle Turtle 
        {
            get => turtle ??= new Turtle(); 
            set => turtle = value; 
        }

        public bool Won => Turtle.Position == Exit;
        public bool Lose => Mines.Contains(Turtle.Position);
        public bool Finished => Won || Lose;
        public bool CanTurtleMove() => !Won && !Lose && Turtle.CanMove(Size);
        public void MoveTurtle() => Turtle.Move();
        public void RotateTurtle() => Turtle.Rotate();

    }
}
