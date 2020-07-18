using System;
using System.Runtime.InteropServices;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using RhinoWPFIntorWorkshop.Veiws;

namespace RhinoWPFIntorWorkshop
{
    [Guid("7DB00C24-124D-4C86-89EC-1D3126E719DD")]
    public class RhinoWPFIntorWorkshopCommand:Command
    {
        public class RhinoWpfIntroPlaneHost : RhinoWindows.Controls.WpfElementHost
        {
            public RhinoWpfIntroPlaneHost(uint docsn) : base
        }

        public RhinoWPFIntorWorkshopCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static RhinoWPFIntorWorkshopCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "RhinoWPFIntorWorkshopCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {

            // ---

            return Result.Success;
        }
    }
}
