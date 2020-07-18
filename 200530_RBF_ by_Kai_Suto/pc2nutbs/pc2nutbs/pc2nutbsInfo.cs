using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace pc2nutbs
{
    public class pc2nutbsInfo:GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "pc2nutbs";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("700f24eb-a371-44ca-8603-de64548e0b7f");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
