using System;
using System.Linq;
using TurtleApp.Crossccutting.Core.Exceptions;
using TurtleApp.UI.TurtleApp.Helpers;
using TurtleApp.UI.TurtleApp.Models;
using TurtleApp.UI.TurtleApp.Screens.Board;
using TurtleApp.UI.TurtleApp.Screens.Errors;
using TurtleApp.UI.TurtleApp.Screens.Help;

namespace TurtleApp.UI.TurtleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (TurtleAppOptions.IsHelp(args))
                {
                    MainHelpScreen.Screen.WriteScreen();
                }
                else
                {
                    var options = ConverterHelper.ConvertToTurtleAppOptions(args);
                    var boar = FileHelper.ImportSetting(options.PathSetting);
                    var actions = FileHelper.ImportActions(options.PathActions);
                    var result = BoardHelper.NextListActionResult(actions, boar);
                    ListResultScreen.Screen.WriteScreen(result);
                }
            }
            catch (ListMessageException ex) when (ex.Errors?.Count > 1)
            {
                ListMessageErrorScreen.Screen.WriteScreen(ex.Errors);
            }
            catch (MessageException ex)
            {
                MessageErrorScreen.Screen.WriteScreen(ex.Message);
            }
            catch
            {
                UnexpectedErrorScreen.Screen.WriteScreen();
            }
            Console.ReadLine();
        }
    }
}
