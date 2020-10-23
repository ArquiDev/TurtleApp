using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Models
{
    class TurtleAppOptions
    {
        public const string PATH_SETTING = "-s";
        public const string PATH_ACTIONS = "-a";
        public const string HELP = "-h";

        public string PathSetting { get; set; }
        public string PathActions { get; set; }


        public bool HasPathSetting => !string.IsNullOrEmpty(PathSetting);
        public bool HasPathActions => !string.IsNullOrEmpty(PathActions);


        public static bool IsHelp(IEnumerable<string> options) => options?.Contains(HELP) ?? false; 
        public static TurtleAppOptionType GetOptionType(string option) => option switch
        {
            PATH_SETTING => TurtleAppOptionType.PathSetting,
            PATH_ACTIONS => TurtleAppOptionType.PathActions,
            _ => TurtleAppOptionType.UNKNOWN,
        };
    }
}
