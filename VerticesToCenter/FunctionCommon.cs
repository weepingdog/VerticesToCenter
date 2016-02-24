using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
namespace VerticesToCenter
{
    public static partial class FunctionCommon
    {  
        

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

        #region "Get Toolbar by Name"

        ///<summary>Obtain a toolbar by specifying it's name.</summary>
        ///  
        ///<param name="application">An IApplication interface.</param>
        ///<param name="toolbarName">A System.String that is the name of the toolbar to return. Example: "esriArcMapUI.StandardToolBar"</param>
        ///   
        ///<returns>An ICommandBar interface.</returns>
        ///  
        ///<remarks>Refer to the EDN document http://edndoc.esri.com/arcobjects/9.1/default.asp?URL=/arcobjects/9.1/ArcGISDevHelp/TechnicalDocuments/Guids/ArcMapIds.htm for a listing of available CLSID's and ProgID's that can be used as the toolbarName parameter.</remarks>
        public static ICommandBar GetToolbarByName(IApplication application, System.String toolbarName)
        {
            ICommandBars commandBars = application.Document.CommandBars;
            ESRI.ArcGIS.esriSystem.UID barID = new ESRI.ArcGIS.esriSystem.UIDClass();
            barID.Value = toolbarName; // Example: "esriArcMapUI.StandardToolBar"
            ICommandItem commandItem = commandBars.Find(barID, false, false);
            if (commandItem != null && commandItem.Type == esriCommandTypes.esriCmdTypeToolbar)
            {
                return (ICommandBar)commandItem;
            }
            else
                return null;
        }
        #endregion

        #region "Get Command on Toolbar by Names"

        ///<summary>Find a command item particularly on a toolbar.</summary>
        ///  
        ///<param name="application">An IApplication interface.</param>
        ///<param name="toolbarName">A System.String that is the name of the toolbar to return. Example: "esriArcMapUI.StandardToolBar"</param>
        ///<param name="commandName">A System.String that is the name of the command to return. Example: "esriFramework.HelpContentsCommand"</param>
        ///   
        ///<returns>An ICommandItem interface.</returns>
        ///  
        ///<remarks>Refer to the EDN document http://edndoc.esri.com/arcobjects/9.1/default.asp?URL=/arcobjects/9.1/ArcGISDevHelp/TechnicalDocuments/Guids/ArcMapIds.htm for a listing of available CLSID's and ProgID's that can be used as the toolbarName and commandName parameters.</remarks>
        public static ICommandItem GetCommandOnToolbar(IApplication application, System.String toolbarName, System.String commandName)
        {
            ICommandBars commandBars = application.Document.CommandBars;
            ESRI.ArcGIS.esriSystem.UID barID = new ESRI.ArcGIS.esriSystem.UIDClass();
            barID.Value = toolbarName; // Example: "esriArcMapUI.StandardToolBar"
            ICommandItem barItem = commandBars.Find(barID, false, false);

            if (barItem != null && barItem.Type == esriCommandTypes.esriCmdTypeToolbar)
            {
                ICommandBar commandBar = (ICommandBar)barItem;
                ESRI.ArcGIS.esriSystem.UID commandID = new ESRI.ArcGIS.esriSystem.UIDClass();
                commandID.Value = commandName; // Example: "esriArcMapUI.AddDataCommand"
                return commandBar.Find(commandID, false);
            }
            else
                return null;
        }
        #endregion

        public static IEnvelope GetEnvlope(IActiveView activeView, IPoint queryPoint, double envlopeDistance)
        {
            IEnvelope envelope = new EnvelopeClass();
            envelope.CenterAt(queryPoint);
            envelope.Width = 2 * envlopeDistance;
            envelope.Height = 2 * envlopeDistance;
            return envelope;           
        }

        public static IPoint Snapping(IActiveView activeView, esriGeometryHitPartType geometryHitPartType, IPoint queryPoint, double searchRaius)
        {
            IPoint vetexPoint = null;
            IPoint hitPoint = new PointClass();
            IHitTest hitTest = null;
            IPointCollection pointCollection = new MultipointClass();
            IProximityOperator proximityOperator = null;
            double hitDistance = 0;
            int hitPartIndex = 0, hitSegmentIndex = 0;
            Boolean rightSide = false;
            IFeatureCache2 featureCache = new FeatureCacheClass();
            featureCache.Initialize(queryPoint, searchRaius);  //初始化缓存
            for (int i = 0; i < activeView.FocusMap.LayerCount; i++)
            {
                //只有点、线、面并且可视的图层才加入缓存
                IFeatureLayer featLayer = (IFeatureLayer)activeView.FocusMap.get_Layer(i);
                if (featLayer != null && featLayer.Visible == true &&
                    (featLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline ||
                    featLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon ||
                    featLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint))                
                {
                    featureCache.AddFeatures(featLayer.FeatureClass, null);
                    for (int j = 0; j < featureCache.Count; j++)
                    {
                        IFeature feature = featureCache.get_Feature(j);
                        hitTest = (IHitTest)feature.Shape;
                        //捕捉节点，另外可以设置esriGeometryHitPartType，捕捉边线点，中间点等。
                        if (hitTest.HitTest(queryPoint, searchRaius, geometryHitPartType, hitPoint, ref hitDistance, ref hitPartIndex, ref hitSegmentIndex, ref rightSide))
                        {
                            object obj = Type.Missing;
                            pointCollection.AddPoint(hitPoint, ref obj, ref obj);
                            break;
                        }
                    }
                }
            }
            proximityOperator = (IProximityOperator)queryPoint;
            double minDistance = 0, distance = 0;
            for (int i = 0; i < pointCollection.PointCount; i++)
            {
                IPoint tmpPoint = pointCollection.get_Point(i);
                distance = proximityOperator.ReturnDistance(tmpPoint);
                if (i == 0)
                {
                    minDistance = distance;
                    vetexPoint = tmpPoint;
                }
                else
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        vetexPoint = tmpPoint;
                    }
                }
            }
            return vetexPoint;            
        }

        public static int GetIndexFromSnapKeyDown(Keys key)
        {
            switch(key)
            {
                case Keys.ControlKey:
                    return 0;
                case Keys.LControlKey:
                    return 1;
                case Keys.RControlKey:
                    return 2;
                case Keys.ShiftKey:
                    return 3;
                case Keys.LShiftKey:
                    return 4;
                case Keys.RShiftKey:
                    return 5;
                default:
                    return 0;
            }
        }

        public static Keys GetSnapKeyDownFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return Keys.ControlKey;
                case 1:
                    return Keys.LControlKey;
                case 2:
                    return Keys.RControlKey;
                case 3:
                    return Keys.ShiftKey;
                case 4:
                    return Keys.LShiftKey;
                case 5:
                    return Keys.RShiftKey;
                default:
                    return Keys.ControlKey;
            }
        }

        public static IElement DrawPointMarker(IMap map, IPoint point)
        {
            IMarkerElement markerElement = new MarkerElementClass();
            ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
            IRgbColor color = new RgbColorClass();
            color.Red = 200;
            color.Green = 100;
            color.Blue = 100;
            simpleMarkerSymbol.Color = color as IColor;
            simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;            
            markerElement.Symbol = simpleMarkerSymbol;

            IElement element = markerElement as IElement;
            element.Geometry = point;

            IGraphicsContainer graphicsContainer = map as IGraphicsContainer;
            graphicsContainer.AddElement(element, 0);
            IActiveView activeView = map as IActiveView;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            return element;
        }

        public static void RemovePointMarker(IMap map)
        { 
            IGraphicsContainer graphicsContainer = map as IGraphicsContainer;
            graphicsContainer.DeleteAllElements();
            IActiveView activeView = map as IActiveView;
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);        
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

        public IPoint PointMoveTo
        {
            get { return m_PointMoveTo; }
        }
        public double DistanceToCenter
        {
            get { return m_DistanceToCenter; }
        }       

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
