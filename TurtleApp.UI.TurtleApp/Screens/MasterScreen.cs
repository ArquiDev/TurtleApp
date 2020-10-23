using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Screens
{
    abstract class MasterScreen
    {
        protected void WriteHead()
        {
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("**                 Turtle Application                          **");
            Console.WriteLine("**                                                             **");
            Console.WriteLine("*****************************************************************");
            Console.WriteLine();
        }
        protected void WriteFood()
        {
            Console.WriteLine();
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("**  Thank you for using Turtle Application.                    **");
            Console.WriteLine("*****************************************************************");
        }
    }
}
