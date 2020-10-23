using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Screens.Board
{
    class ListResultScreen : MasterScreenModel<ListResultScreen, List<string>>
    {
        protected override void WriteBody(List<string> model)
        {
            foreach (var line in model)
            {
                Console.WriteLine(line);
            }
        }
    }
}
