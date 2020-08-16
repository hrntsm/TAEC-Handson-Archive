using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using Rhino.Geometry;

namespace Magnet_Component {
    public class CustomAttributes:GH_ComponentAttributes {
        public CustomAttributes(MagnetComponent owner) : base(owner) {
        }

        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel) {
            if (channel == GH_CanvasChannel.Objects) {
                GH_PaletteStyle style = GH_Skin.palette_hidden_standard;
                GH_Skin.palette_hidden_standard = new GH_PaletteStyle(Color.DeepPink, Color.Teal, Color.PapayaWhip);
                base.Render(canvas, graphics, channel);
                GH_Skin.palette_hidden_standard = style;
            }
        }
        //a = GH_FontServer.
    }
}
