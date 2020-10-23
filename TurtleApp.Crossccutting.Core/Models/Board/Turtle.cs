using System;
using System.Drawing;

namespace TurtleApp.Crossccutting.Core.Models.Board
{
    public class Turtle
    {
        public TurtleDirectionType Direction { get; set; }
        public Point Position { get; set; }
        public void Rotate() => Direction = Direction switch
        {
            TurtleDirectionType.North => TurtleDirectionType.East,
            TurtleDirectionType.East => TurtleDirectionType.South,
            TurtleDirectionType.South => TurtleDirectionType.West,
            TurtleDirectionType.West => TurtleDirectionType.North,
            _ => throw new Exception() //this never can happen.
        };
        public void Move() => Position = Direction switch
        {
            TurtleDirectionType.North => new Point(Position.X, Position.Y - 1),
            TurtleDirectionType.East => new Point(Position.X + 1, Position.Y),
            TurtleDirectionType.South => new Point(Position.X, Position.Y + 1),
            TurtleDirectionType.West => new Point(Position.X - 1, Position.Y),
            _ => throw new Exception() //this never can happen.
        };
        public bool CanMove(Size size) => Direction switch
        {
            TurtleDirectionType.North when Position.Y == 0 => false,
            TurtleDirectionType.East when Position.X == size.Width - 1 => false,
            TurtleDirectionType.South when Position.Y == size.Height - 1 => false,
            TurtleDirectionType.West when Position.X == 0 => false,
            _ => true
        };

    }
}
