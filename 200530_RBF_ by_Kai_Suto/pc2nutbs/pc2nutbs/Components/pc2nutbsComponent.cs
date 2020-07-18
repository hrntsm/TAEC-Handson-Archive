using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using pc2nurbs.Classes;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace pc2nurbs.Components
{
    public class pc2nurbsComponent:GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public pc2nurbsComponent()
            : base("RBF from PCloud", "RBF PCloud",
            "Create a RBF instance.",
            "PlayGround", "RBF")

        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {   
            pManager.AddPointParameter("Sample Pts", "Pts", "Sampling point to interpolate.", GH_ParamAccess.list);
            pManager.AddPlaneParameter("Plane", "P", "A reference plane.", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Number of Layers", "nLayers", "A number of layers of a RBF network.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Radius of Basis Function", "rBase", "A radius of the RBF.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Smooth Prameter", "Smooth", "A parameter of smoothing of a RBF network", GH_ParamAccess.item);
        }


        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("RBF", "RBF", "A RBF Interpolation instance which create interpolated surface from the input point cloud.", GH_ParamAccess.item);
        }


        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Point3d> samplePts = new List<Point3d>();
            Plane plane = new Plane();
            int nLayers = 3;
            double rBase = 1;
            double smooth = 0;

            DA.GetDataList(0, samplePts);
            DA.GetData(1, ref plane);
            DA.GetData(2, ref nLayers);
            DA.GetData(3, ref rBase);
            DA.GetData(4, ref smooth);

            RBFInterpolation rbf = new RBFInterpolation(samplePts, plane, nLayers, rBase, smooth);

            DA.SetData(0, rbf);
        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("07C835C4-DCB5-419C-8A03-9E0384C43E1C"); }
        }
    }
}
