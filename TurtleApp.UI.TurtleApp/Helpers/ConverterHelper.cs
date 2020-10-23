using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using TurtleApp.Crossccutting.Core.Exceptions;
using TurtleApp.UI.TurtleApp.Models;

namespace TurtleApp.UI.TurtleApp.Helpers
{
    static class ConverterHelper
    {
        public static TurtleAppOptions ConvertToTurtleAppOptions(IEnumerable<string> args)
        {
            string path;
            var options = new TurtleAppOptions();
            var msgErrors = new List<string>();
            var argQueue = new Queue<string>(args);
            while (argQueue.TryDequeue(out string param))
            {
                try
                {
                    switch (TurtleAppOptions.GetOptionType(param))
                    {
                        case TurtleAppOptionType.PathSetting:
                            if (GetArgPath(ref argQueue, out path))
                                options.PathSetting = path;
                            else
                                msgErrors.Add($"Incorrect option format: It was provider {TurtleAppOptions.PATH_SETTING} but not a path.");
                            break;
                        case TurtleAppOptionType.PathActions:
                            if (GetArgPath(ref argQueue, out path))
                                options.PathActions = path;
                            else
                                msgErrors.Add($"Incorrect option format: It was provider {TurtleAppOptions.PATH_ACTIONS} but not a path.");
                            break;
                        default:
                            msgErrors.Add($"The parameter {param} is unknown.");
                            break;
                    }
                }
                catch
                {
                    msgErrors.Add("Something happen processing the parameters, please try again.");
                }
            }
            if (msgErrors.Any())
                throw new ListMessageException(msgErrors);
            return options;
        }
        private static bool GetArgPath(ref Queue<string> argQueue, out string path)
        {
            var result = argQueue.TryPeek(out string tempPath) &&
                            TurtleAppOptions.GetOptionType(tempPath) == TurtleAppOptionType.UNKNOWN;
            path = result ? argQueue.Dequeue() : string.Empty;
            return result;
        }
        
    }
}
