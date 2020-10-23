using System;
using System.Collections.Generic;
using System.Text;
using TurtleApp.UI.TurtleApp.Models;

namespace TurtleApp.UI.TurtleApp.Screens.Help
{
    class MainHelpScreen : MasterScreenFixed<MainHelpScreen>
    {
        protected override void WriteBody()
        {
            Console.WriteLine($"{TurtleAppOptions.PATH_SETTING} PATH => Is the option to set the setting file");
            Console.WriteLine("                where PATH is the absolute path.");
            Console.WriteLine();
            Console.WriteLine($"{TurtleAppOptions.PATH_ACTIONS} PATH  => Is the option to set the action file");
            Console.WriteLine("                where PATH is the absolute path.");
            Console.WriteLine();
            Console.WriteLine($"{TurtleAppOptions.HELP}       => Is the option show help.");
        }
    }
}
