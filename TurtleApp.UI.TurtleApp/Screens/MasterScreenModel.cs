using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleApp.UI.TurtleApp.Screens
{
    class MasterScreenModel<TScreen, TModel> : MasterScreen where TScreen : MasterScreen, new()
    {
        protected static TScreen screen;
        protected MasterScreenModel() : base() { }
        public static TScreen Screen => screen ??= new TScreen();

        protected virtual void WriteBody(TModel model) { }
        public void WriteScreen(TModel model)
        {
            WriteHead();
            WriteBody(model);
            WriteFood();
        }
    }
}
