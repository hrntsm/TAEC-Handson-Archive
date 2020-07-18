using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace Magnet_Component {
    public class Magnet_ComponentInfo:GH_AssemblyInfo {
        public override string Name {
            get {
                return "MagnetComponent";
            }
        }
        public override Bitmap Icon {
            get {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description {
            get {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id {
            get {
                return new Guid("216a09bb-a1fc-4795-8bc9-374c20817be8");
            }
        }

        public override string AuthorName {
            get {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact {
            get {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
