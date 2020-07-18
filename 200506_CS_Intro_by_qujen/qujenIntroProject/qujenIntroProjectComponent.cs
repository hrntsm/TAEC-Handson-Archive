using System;
using System.Drawing;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace qujenIntroProject
{
    public class qujenIntroProjectComponent:GH_Param<GH_Integer>
    {
        public qujenIntroProjectComponent()
            :base(new GH_InstanceDescription("Panel Integer", "PInt", "Provide integer", "PlayGround", "qujen"))
        {
        }

        private int m_value = 6;
        public int Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public override void CreateAttributes()
        {
            m_attributes = new IntroComponentAttribute(this);
        }

        protected override void CollectVolatileData_Custom()
        {
            VolatileData.Clear();
            AddVolatileData(new Grasshopper.Kernel.Data.GH_Path(0), 0, new GH_Integer(Value));
        }
        
        public override bool Write(GH_IO.Serialization.GH_IWriter writer)
        {
            writer.SetInt32("SpecialInteger", m_value);
            return base.Write(writer);
        }
        public override bool Read(GH_IO.Serialization.GH_IReader reader)
        {
            m_value = 0;
            reader.TryGetInt32("SpecialInteger", ref m_value);
            return base.Read(reader);
        }

        public override GH_Exposure Exposure => GH_Exposure.primary | GH_Exposure.obscure;

        protected override Bitmap Icon => null;

        public override Guid ComponentGuid =>  new Guid("38e16066-e0b0-4f70-92a4-4f490994c9f3");
    }

    public class IntroComponentAttribute : GH_Attributes<qujenIntroProjectComponent>
    {
        private int[][] m_square;

        private const int ButtonSize = 48;

        public override bool HasInputGrip { get {return false;} }
        public override bool HasOutputGrip { get {return true;} }

        public IntroComponentAttribute(qujenIntroProjectComponent ower)
            :base(ower)
        {
            m_square = new int[3][];
            m_square[0] = new int[3] { 0, 1, 2 };
            m_square[1] = new int[3] { 3, 4, 5 };
            m_square[2] = new int[3] { 6, 7, 8 };
        }

        private Rectangle Button(int column, int row)        {            int x = Convert.ToInt32(Pivot.X);            int y = Convert.ToInt32(Pivot.Y);            return new Rectangle(x + column * ButtonSize, y + row * ButtonSize, ButtonSize, ButtonSize);        }        private int Value(int column, int row)        {            return m_square[row][column];        }

        public override void SetupTooltip(PointF point, GH_TooltipDisplayEventArgs e)
        {
            base.SetupTooltip(point, e);
            e.Description = "Please Double Click";
        }

        public override GH_ObjectResponse RespondToMouseDown(GH_Canvas sender, GH_CanvasMouseEvent e)        {            if (e.Button == System.Windows.Forms.MouseButtons.Left)            {                for (int col = 0; col < 3; col++)                {                    for (int row = 0; row < 3; row++)                    {                        RectangleF button = Button(col, row);                        if (button.Contains(e.CanvasLocation))                        {                            int value = Value(col, row);                            Owner.RecordUndoEvent("Square Change");                            Owner.Value = value;                            Owner.ExpireSolution(true);                            return GH_ObjectResponse.Handled;                        }                    }                }            }            return base.RespondToMouseDoubleClick(sender, e);        }


        protected override void Layout()
        {
            Pivot = GH_Convert.ToPoint(Pivot);
            Bounds = new RectangleF(Pivot, new SizeF(3 * ButtonSize, 3 * ButtonSize));
        }

        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
        {
            if (channel == GH_CanvasChannel.Objects)            {                GH_CapsuleRenderEngine.RenderOutputGrip(graphics, canvas.Viewport.Zoom, OutputGrip, true);                for (int col = 0; col < 3; col++)                {                    for (int row = 0; row < 3; row++)                    {                        int value = Value(col, row);                        Rectangle button = Button(col, row);                        GH_Palette palette = GH_Palette.White;                        if (value == Owner.Value)
                        {
                            palette = GH_Palette.Blue;
                        }                        GH_Capsule capsule = GH_Capsule.CreateTextCapsule(button, button, palette, value.ToString(), 0, 0);                        capsule.Render(graphics, Selected, Owner.Locked, true);                        capsule.Dispose();                    }                }            }
        }
    }

}
