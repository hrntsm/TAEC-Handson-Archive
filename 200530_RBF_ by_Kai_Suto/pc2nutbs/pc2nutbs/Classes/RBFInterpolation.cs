using Rhino.Geometry;
using System.Collections.Generic;
using System.Linq;

namespace pc2nurbs.Classes
{
    class RBFInterpolation
    {
        #region Constructros
        public RBFInterpolation()
        {

        }
        public RBFInterpolation(List<Point3d> pts, Plane plane, int nLayers, double rBase, double smooth)
        {
            this.SamplePts = pts;
            this.Plane = plane;
            this.nLayers = nLayers;
            this.rBase = rBase;
            this.smooth = smooth;
            SetProperties(pts, plane);
        }
        #endregion

        #region Properties
        public List<Point3d> SamplePts { get; private set; }
        public Plane Plane { get; private set; }
        public alglib.rbfmodel Model { get; private set; }
        #endregion

        #region Public Methods
        public double Z(double x, double y)
        {
            double xScaled = x / this.xLength;
            double yScaled = y / this.yLength;
            double zScaled = alglib.rbfcalc2(this.Model, xScaled, yScaled);
            double z = zScaled * zLength;

            return z;
        }
        public Point3d P(double x, double y)
        {

            double z = this.Z(x, y);
            Vector3d zDir = this.Plane.Normal;
            Point3d ptOnPlane = this.Plane.PointAt(x, y);
            Point3d p = ptOnPlane + z * zDir;
            return p;
        }
        public Surface InterpolatedSurface(double xStart, double xEnd, double yStart, double yEnd, int U, int V)
        {
            // U 方向のネットワークスプライン曲線群を作る
            Curve[] uCurves = new Curve[U + 1];
            for(int i = 0; i < U+1; i++)
            {
                double stepY = (yEnd - yStart) / V;
                double y = yStart + i * stepY;
                Point3d[] pts = new Point3d[V + 1];
                for(int j = 0; j < V+1; j++)
                {
                    double stepX = (xEnd - xStart) / U;
                    double x = xStart + j * stepX;
                    double z = this.Z(x, y);
                    pts[j] = new Point3d(x, y, z);
                }
                uCurves[i] = NurbsCurve.CreateInterpolatedCurve(pts, 3);
            }
            // V 方向のネットワークスプライン曲線群を作る
            Curve[] vCurves = new Curve[V + 1];
            for (int i = 0; i < V + 1; i++)
            {
                double stepX = (xEnd - xStart) / U;
                double x = xStart + i * stepX;
                Point3d[] pts = new Point3d[U + 1];
                for (int j = 0; j < U + 1; j++)
                {
                    double stepY = (yEnd - yStart) / V;
                    double y = xStart + j * stepY;
                    double z = this.Z(x, y);
                    pts[j] = new Point3d(x, y, z);
                }
                vCurves[i] = NurbsCurve.CreateInterpolatedCurve(pts, 3);
            }
            // Network Surface の構築
            int error;
            Surface interpolatedSurface = NurbsSurface.CreateNetworkSurface(uCurves, 1, 1, vCurves, 1, 1, 0.1, 0.1, 0.1, out error);
            return interpolatedSurface;
        }
        #endregion

        #region Private Members
        private int numSamplePoints;
        private double[] x;
        private double[] y;
        private double[] z;
        private double xLength;
        private double yLength;
        private double zLength;
        private double[,] samplePlanarCoordsScaled;
        private int nLayers = 3;
        private double rBase = 1.0;
        private double smooth = 0.0;
        #endregion

        #region Private Methods
        private void SetNumSamplePoints(List<Point3d> pts)
        {
            this.numSamplePoints = pts.Count;
        }
        private void SetXYZ(List<Point3d> pts, Plane plane)
        {
            this.x = new double[pts.Count];
            this.y = new double[pts.Count];
            this.z = new double[pts.Count];
            for (int i = 0; i < pts.Count; i++)
            {
                double xi = 0;
                double yi = 0;
                double zi = 0;
                // 点の基準平面上への射影点を求める
                Point3d onPlanePoint = plane.ClosestPoint(pts[i]);
                // 射影点での基準平面上での座標を求める
                plane.ClosestParameter(onPlanePoint, out xi, out yi);
                // 点の基準平面上での距離を求める
                zi = onPlanePoint.DistanceTo(pts[i]);
                // 基準平面の裏側にあったら負の値にする
                if ((pts[i] - onPlanePoint) * plane.Normal < 0) zi *= -1;
                this.x[i] = xi;
                this.y[i] = yi;
                this.z[i] = zi;
            }
        }
        private void SetXYZLength()
        {
            this.xLength = this.x.Max() - this.x.Min();
            this.yLength = this.y.Max() - this.y.Min();
            this.zLength = this.z.Max() - this.z.Min();
        }
        private void SetScalizedPlanarCoordinates()
        {
            this.samplePlanarCoordsScaled = new double[this.numSamplePoints, 3];
            for(int i = 0; i < this.numSamplePoints; i++)
            {
                this.samplePlanarCoordsScaled[i, 0] = this.x[i] / this.xLength;
                this.samplePlanarCoordsScaled[i, 1] = this.y[i] / this.yLength;
                this.samplePlanarCoordsScaled[i, 2] = this.z[i] / this.zLength;
            }
        }
        private void SetRBFModel()
        {
            // RBF Model を宣言
            alglib.rbfmodel model;
            // 入力が2次元、出力が１次元として RBF Model を初期化
            alglib.rbfcreate(2, 1, out model);
            // サンプル点を RBF Model にセット
            alglib.rbfsetpoints(model, this.samplePlanarCoordsScaled);
            alglib.rbfsetalgohierarchical(model, this.rBase, this.nLayers, this.smooth);
            // モデル構築に関する情報を入れるクラスを宣言
            alglib.rbfreport rep;
            // RBF Model 構築
            alglib.rbfbuildmodel(model, out rep);
            // クラスプロパティに代入
            this.Model = model;
        }
        private void SetProperties(List<Point3d> pts, Plane plane)
        {
            SetNumSamplePoints(pts);
            SetXYZ(pts, plane);
            SetXYZLength();
            SetScalizedPlanarCoordinates();
            SetRBFModel();
        }
        #endregion


    }
}
