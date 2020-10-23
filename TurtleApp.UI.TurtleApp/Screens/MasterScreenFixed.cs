using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Screens
{
    class MasterScreenFixed<T> : MasterScreen where T : MasterScreen, new()
    {
        protected static T screen;
        protected MasterScreenFixed() : base() { }
        public static T Screen => screen ??= new T();

        protected virtual void WriteBody() { }
        public void WriteScreen()
        {
            WriteHead();
            WriteBody();
            WriteFood();
        }
    }
}
