using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Screens.Errors
{
    class UnexpectedErrorScreen : MasterScreenFixed<UnexpectedErrorScreen>
    {
        protected override void WriteBody()
        {
            Console.WriteLine("Something unexpected happen, please try again later.");
        }
    }
}
