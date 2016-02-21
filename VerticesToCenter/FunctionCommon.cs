using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
namespace VerticesToCenter
{
    public static class FunctionCommon
    {
        //从要素图层获取图层名
        public static string GetLayerNameFromFeature(IFeature feature)
        {
            //Mark 手动修改层名可能会出现问题
            return feature.Class.AliasName;
        }
        //从要素图层获取图层名
        public static string GetNameFromFeatureLayer(IFeatureLayer featureLayer)
        {
            //Mark 手动修改层名可能会出现问题
            return featureLayer.Name;
        }
        //从要素图层列表里获取指定名称要素图层,仅第一个匹配要素图层
        public static IFeatureLayer GetFeatureLayerWithName(string name, IList<IFeatureLayer> featureLayerList)
        {
            IFeatureLayer pFeatureLayer = null;
            foreach (IFeatureLayer featureLayer in featureLayerList)
                if (name == FunctionCommon.GetNameFromFeatureLayer(featureLayer))
                {
                    pFeatureLayer = featureLayer;
                    break;
                }
            return pFeatureLayer; 
        }

        //从地图内获取可编辑要素图层列表
        public static IList<IFeatureLayer> GetEditablePolyLines(IMap map)
        {
            IList<IFeatureLayer> pEditablePolyLines = new List<IFeatureLayer>();
            IEnumLayer pEnumLayer = map.get_Layers();
            pEnumLayer.Reset();
            ILayer pLayer = pEnumLayer.Next();
            while (pLayer != null)
            {
                //Mark 非要素图层是否有问题
                IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                IDatasetEdit pDataEdit = pFeatureClass as IDatasetEdit;
                if (pDataEdit.IsBeingEdited() && pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    pEditablePolyLines.Add(pFeatureLayer);
                pLayer = pEnumLayer.Next();
            }
            return pEditablePolyLines;
        }
       
        //获取两点距离
        public static double GetDistance2P(IPoint pt1, IPoint pt2)
        {
            if (pt1 == null || pt2 == null)
                return -0.1;
            double x1 = pt1.X;
            double y1 = pt1.Y;
            double x2 = pt2.X;
            double y2 = pt2.Y;
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        //圆弧(线)转多边形(圆)
        public static IPolygon CircularArcToPolygon(ICircularArc pCircularArc)
        {
            ISegmentCollection pSegmentCollection = new PolygonClass();
            object missing1 = System.Type.Missing;
            object missing2 = System.Type.Missing;
            pSegmentCollection.AddSegment(pCircularArc as ISegment, ref missing1, ref missing2);


            IPolygon pPolygon = pSegmentCollection as IPolygon;
            return pPolygon;
        }

        //圆弧(线)转圆几何
        public static IGeometry GetCircleGeometry(ICircularArc pCircularArc)
        {
            ISegmentCollection pSegmentCollection = new PolygonClass();
            object missing1 = System.Type.Missing;
            object missing2 = System.Type.Missing;
            pSegmentCollection.AddSegment(pCircularArc as ISegment, ref missing1, ref missing2);


            IGeometry pGeometry = pSegmentCollection as IGeometry;
            return pGeometry;
        }

        //点+半径转圆几何
        public static IGeometry GetCircleGeometry(IPoint pPoint, double radius)
        {
            ICircularArc pCircularArc = new CircularArcClass();
            IConstructCircularArc pConstructCircularArc = pCircularArc as IConstructCircularArc;
            pConstructCircularArc.ConstructCircle(pPoint, radius, true);
            return GetCircleGeometry(pCircularArc);

        }

        public static IGeometry GetCircleGeometry(IPoint pPointCenter, IPoint pPointTo)
        {
            double radius = GetDistance2P(pPointCenter, pPointTo);
            return GetCircleGeometry(pPointCenter, radius);
        }
        //-1:无效ID; 0:首点ID; 正数:末点ID
        public static Tuple<int, int> GetPointIDPairFromFeature(
            IFeature feature, 
            IPoint point, 
            double radius, 
            EnumSelectMode selectMode)
        {
            if (feature == null)
                return new Tuple<int, int>(-1, -1);
            IGeometry Geometry = feature.Shape;
            IPointCollection PointCollection = Geometry as IPointCollection;
            int pointCount = PointCollection.PointCount;             //几何点集个数
            IPoint pt0 = PointCollection.get_Point(0);               //首点
            IPoint ptn = PointCollection.get_Point(pointCount - 1);  //末点
            double s0 = GetDistance2P(point, pt0);                   //首点到目标点距离
            double sn = GetDistance2P(point, ptn);                   //末点到目标点距离
            bool bChanged0 = false;                                  //首点是否符合移动条件
            bool bChangedn = false;                                  //末点是否符合移动条件
            switch (selectMode)
            {
                //1 最近点
                case EnumSelectMode.MostNearOne:
                    bChanged0 = (s0 < sn) && (s0 < radius);
                    bChangedn = (!(s0 < sn)) && (sn < radius);
                    break;
                //2 第一点
                case EnumSelectMode.OnlyFirst:
                    bChanged0 = (s0 < radius);
                    break;
                //3 最后点
                case EnumSelectMode.OnlyLast:
                    bChangedn = (sn < radius);
                    break;
                //4 两端点
                case EnumSelectMode.BothFirstAndLast:
                    bChanged0 = (s0 < radius);
                    bChangedn = (sn < radius);
                    break;
            }
            int item1 = bChanged0 ? 0 : -1;
            int item2 = bChangedn ? pointCount - 1 : -1;
            return new Tuple<int, int>(item1, item2);
        }
        //null:无效
        public static Tuple<IPoint, IPoint> GetPointPairFromFeature(
            IFeature feature,
            IPoint point,
            double radius,
            EnumSelectMode selectMode)
        {
            if (feature == null)
                return new Tuple<IPoint, IPoint>(null, null);
            IGeometry Geometry = feature.Shape;
            IPointCollection PointCollection = Geometry as IPointCollection;
            int pointCount = PointCollection.PointCount;             //几何点集个数
            IPoint pt0 = PointCollection.get_Point(0);               //首点
            IPoint ptn = PointCollection.get_Point(pointCount - 1);  //末点
            double s0 = GetDistance2P(point, pt0);                   //首点到目标点距离
            double sn = GetDistance2P(point, ptn);                   //末点到目标点距离
            bool bChange0 = false;                                  //首点是否符合移动条件
            bool bChangen = false;                                  //末点是否符合移动条件
            switch (selectMode)
            {
                //1 最近点
                case EnumSelectMode.MostNearOne:
                    bChange0 = (s0 < sn) && (s0 < radius);
                    bChangen = (!(s0 < sn)) && (sn < radius);
                    break;
                //2 第一点
                case EnumSelectMode.OnlyFirst:
                    bChange0 = (s0 < radius);
                    break;
                //3 最后点
                case EnumSelectMode.OnlyLast:
                    bChangen = (sn < radius);
                    break;
                //4 两端点
                case EnumSelectMode.BothFirstAndLast:
                    bChange0 = (s0 < radius);
                    bChangen = (sn < radius);
                    break;
            }
            IPoint item1 = bChange0 ? pt0 : null;
            IPoint item2 = bChangen ? ptn : null;
            return new Tuple<IPoint, IPoint>(item1, item2);
        }

        public static double GetMapUnit(IActiveView activeView)
        {
            IDisplayTransformation DisplayTransformation = activeView.ScreenDisplay.DisplayTransformation;
            IPoint Point1 = DisplayTransformation.VisibleBounds.UpperLeft;
            IPoint Point2 = DisplayTransformation.VisibleBounds.UpperRight;
            int x1, x2, y1, y2;
            DisplayTransformation.FromMapPoint(Point1, out x1, out y1);
            DisplayTransformation.FromMapPoint(Point2, out x2, out y2);
            double pixelExtent = x2 - x1;
            double realWorldDisplayExtent = DisplayTransformation.VisibleBounds.Width;
            return realWorldDisplayExtent / pixelExtent;
        }
    }
    public enum EnumSelectMode
    {
        MostNearOne = 0,//最近点
        OnlyFirst = 1,//首点 ID=0-，实际的末点
        OnlyLast = 2, //末点，ID=N-1，实际的首点
        BothFirstAndLast = 3,//两端的点
    }
    public class TrackPoint : IComparable
    {
        private IPoint m_PointMoveTo;
        private double m_DistanceToCenter;
        //private INewLineFeedback m_NewLineFeedback;

        public IPoint PointMoveTo
        {
            get { return m_PointMoveTo; }
        }
        public double DistanceToCenter
        {
            get { return m_DistanceToCenter; }
        }
        //public INewLineFeedback NewLineFeedback
        //{
        //    get { return m_NewLineFeedback; }
        //    set { m_NewLineFeedback = value; }
        //}

        public TrackPoint(IPoint pointStart, IPoint pointMoveTo)
        {
            SetPoint(pointStart, pointMoveTo); 
        }
        public void SetPoint(IPoint pointStart, IPoint pointMoveTo)
        {
            m_PointMoveTo = pointMoveTo;
            m_DistanceToCenter = FunctionCommon.GetDistance2P(pointStart, pointMoveTo);
        }
        public int CompareTo(System.Object obj)
        {
            if (obj is TrackPoint)
            {
                TrackPoint trackpoint = obj as TrackPoint;
                return Convert.ToInt16(this.m_DistanceToCenter - trackpoint.m_DistanceToCenter);
            }
            else
            {
                throw new ArgumentException("Object to compare to is not a Line object.");
            }
        }        

    }
}
