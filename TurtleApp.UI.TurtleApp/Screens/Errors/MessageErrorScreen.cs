using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Screens.Errors
{
    class MessageErrorScreen : MasterScreenModel<MessageErrorScreen, string>
    {
        protected override void WriteBody(string model)
        {
            Console.WriteLine(model);
            Console.WriteLine();
            Console.WriteLine("Use -h option to show help.");
        }
    }
}
