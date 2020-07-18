using System;
using Rhino;
using Rhino.UI;
using Rhino.Commands;
using RhinoWindows;

namespace RhinoWPFIntorWorkshop.Commands
{
    public class HelloDialog : Command
    {
        public override string EnglishName
        {
            get { return "HelloDialog"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: complete command.
            //Dialogs.ShowMessage("Hello World!!", "My First Dialog");
            var dialog = new Veiws.Dialog();
            dialog.ShowSemiModel(RhinoApp.MainWindowHandle());
            return Result.Success;
        }
    }
}