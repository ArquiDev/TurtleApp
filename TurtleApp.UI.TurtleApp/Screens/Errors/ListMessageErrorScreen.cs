using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Screens.Errors
{
    class ListMessageErrorScreen : MasterScreenModel<ListMessageErrorScreen, List<string>>
    {
        protected override void WriteBody(List<string> model)
        {
            Console.WriteLine("The following errors was found on the parameters:");
            foreach (var error in model)
            {
                Console.WriteLine($" - {error}");
            }
            Console.WriteLine();
            Console.WriteLine("Use -h option to show help.");
        }
    }
}
