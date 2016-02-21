using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace VerticesToCenter
{
    public class ToolVerticesToCenter : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        private bool m_isMouseDown = false;
        private IPoint m_PointCentre;
        
        private INewCircleFeedback m_CircleFeedback;    //3 跟踪圆

        private int m_LastSelectFeatureCount = 0;
        private double m_LastRadius = 0;
        private int m_LastTrackPointCount = 0;
        private IList<TrackPoint> m_TrackPointList = new List<TrackPoint>();

        #region "1 System Event"
        public ToolVerticesToCenter()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = (ArcMap.Application != null&&GlobeStatus.IsEditing&&GlobeStatus.CheckedPolyLines.Count>0);         
        }

        protected override void OnActivate()
        {
            this.Cursor = System.Windows.Forms.Cursors.Cross;
        }

        protected override bool OnDeactivate()
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            return base.OnDeactivate();
        }
        #endregion

        #region "2 Mouse Event"
        protected override void OnMouseDown(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            //清空选择集
            GlobeStatus.Map.ClearSelection();
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            //GlobeStatus.ActiveView.Refresh(); 

            //鼠标按下点作为圆心点//或者捕捉
            IPoint PointMouseDown = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (PointMouseDown == null)
                return;
            if (GlobeStatus.CenterSnap)
            {
                m_PointCentre = PointSnapWhenMouseDown(PointMouseDown, GlobeStatus.PixelRadiusChangeLimit);
            }
            else
            {
                m_PointCentre = PointMouseDown;
            }

            //开始追踪圆
            CircleFeedBackWhenMouseDown(m_PointCentre);
            
            //开始追踪移动点
            TrackPointFeedBackWhenMouseDown(m_PointCentre);

            m_isMouseDown = true;
        }
        private void CircleFeedBackWhenMouseDown(IPoint pointCentre)
        {
            //开始追踪圆
            if (m_CircleFeedback == null)
            {
                m_CircleFeedback = new NewCircleFeedbackClass();
                m_CircleFeedback.Display = GlobeStatus.ActiveView.ScreenDisplay;
                m_CircleFeedback.Start(pointCentre);
            }
        }
        
        private void TrackPointFeedBackWhenMouseDown(IPoint pointCentre)
        {
            //正常情况下，此时TrackPointCount为0
            int TrackPointCount = m_TrackPointList.Count;
            for (int i = TrackPointCount-1; i >0 ; i--)
                m_TrackPointList[i].NewLineFeedback = null;
            m_TrackPointList.Clear();
        }

        protected override void OnMouseMove(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            //鼠标未按下无效（要等同于拖曳操作）,但提示捕捉圆心点(在开启捕捉情况下)
            if (!m_isMouseDown)
            {
                if (GlobeStatus.CenterSnap)
                    PointSnapWhenMouseMove();
                return; 
            }

            //移动到的点
            IPoint PointMouseMoveTo = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (PointMouseMoveTo == null)
                return;

            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            
            //跟踪圆
            CircleFeedBackWhenMouseMove(PointMouseMoveTo);
           
            //追踪多个待移动的点
            TrackPointFeedBackWhenMouseMove(m_PointCentre,PointMouseMoveTo,GlobeStatus.SelectMode);

            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            //GlobeStatus.ActiveView.Refresh();
        }
        private void CircleFeedBackWhenMouseMove(IPoint pointMouseMoveTo)
        {
            double currentRadius = FunctionCommon.GetDistance2P(m_PointCentre, pointMouseMoveTo);

            //1 选择半径太大，不响应
            if (currentRadius > GlobeStatus.PixelMaxRadius * GlobeStatus.MapUnit)
            {
                //GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                return;
            }
            if (m_CircleFeedback != null)
                m_CircleFeedback.MoveTo(pointMouseMoveTo);
        }
     
        private void TrackPointFeedBackWhenMouseMove(IPoint pointCentre, IPoint pointMouseMoveTo, EnumSelectMode SelectMode)
        {
            double currentRadius = FunctionCommon.GetDistance2P(m_PointCentre, pointMouseMoveTo);

            //1 选择半径太大，不响应
            if (currentRadius > GlobeStatus.PixelMaxRadius * GlobeStatus.MapUnit)
            {
                return;
            }

            //2 变化距离太小，不响应
            double distanceChange = currentRadius - m_LastRadius;            
            if (Math.Abs(distanceChange) < GlobeStatus.PixelRadiusChangeLimit * GlobeStatus.MapUnit)
            {
                return;
            }

            //3 开始选择
            IGeometry pGeometry = FunctionCommon.GetCircleGeometry(m_PointCentre, currentRadius);
            ISelectionEnvironment env = new SelectionEnvironmentClass();
            env.CombinationMethod = esriSelectionResultEnum.esriSelectionResultNew;
            GlobeStatus.Map.SelectByShape(pGeometry, env, false);
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, pGeometry.Envelope);
            int currentSelectFeatureCount=GlobeStatus.Map.SelectionCount;

            //4 选择个数过多，放弃选择
            if (currentSelectFeatureCount > GlobeStatus.PixelMaxFeaturesSelect)
            {
                return;
            }
            if (distanceChange < 0)
            {
                int CurrentTrackPointCount = m_TrackPointList.Count;

                for (int i = CurrentTrackPointCount - 1; i >= 0; i--)
                {
                    if (m_TrackPointList[i].DistanceToCenter > currentRadius)
                    {                        
                        m_TrackPointList[i].NewLineFeedback = null;
                        m_TrackPointList.RemoveAt(i);                        
                    }
                }

                if (m_LastTrackPointCount > m_TrackPointList.Count)
                {
                    m_LastTrackPointCount = m_TrackPointList.Count;
                    m_LastRadius = currentRadius;
                }
            }
            else
            {
                ISelection pSelection = GlobeStatus.Map.FeatureSelection;
                IEnumFeatureSetup pEnumFeatureSetup = pSelection as IEnumFeatureSetup;
                IEnumFeature pRnumFeature = pEnumFeatureSetup as IEnumFeature;
                pRnumFeature.Reset();
                IFeature pFeature = pRnumFeature.Next();
                while (pFeature != null)
                {
                    string FeatureLayerName = FunctionCommon.GetLayerNameFromFeature(pFeature);
                    if (!(GlobeStatus.CheckedPolyLines.Contains(FeatureLayerName)))
                        continue;
                    
                    Tuple<IPoint, IPoint> PointPair=FunctionCommon.GetPointPairFromFeature(pFeature,pointCentre,currentRadius,SelectMode);
                    if (PointPair.Item1 != null)
                        m_TrackPointList.Add(new TrackPoint(pointCentre, PointPair.Item1));
                    if (PointPair.Item2 != null)
                        m_TrackPointList.Add(new TrackPoint(pointCentre, PointPair.Item2));                  

                    pFeature = pRnumFeature.Next();
                }                
                int CurrentTrackPointCount=m_TrackPointList.Count;
                if (m_LastTrackPointCount < CurrentTrackPointCount)
                {
                    for (int i = m_LastTrackPointCount; i < CurrentTrackPointCount; i++)
                    {                        
                        if (m_TrackPointList[i].NewLineFeedback == null)
                        {
                            m_TrackPointList[i].NewLineFeedback = new NewLineFeedback();
                            m_TrackPointList[i].NewLineFeedback.Display = GlobeStatus.ActiveView.ScreenDisplay;
                            m_TrackPointList[i].NewLineFeedback.Start(m_PointCentre);
                            m_TrackPointList[i].NewLineFeedback.MoveTo(m_TrackPointList[i].PointMoveTo);
                        }
                    }
                    m_LastRadius = currentRadius;
                    m_LastTrackPointCount = CurrentTrackPointCount;
                }
            }
        }

        protected override void OnMouseUp(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            //鼠标不再按下
            m_isMouseDown = false;

            //鼠标放开时的点
            IPoint PointMouseUp = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (PointMouseUp == null)
                return;

            //追踪圆停止
            //（并存取圆弧，用于构造圆形；
            //实际上也可以利用圆心(鼠标按下)，圆上一点（鼠标放开）来构造圆形）
            CircleFeedbackWhenMouseUp(PointMouseUp);            

            //追踪多点停止，修改几何
            TrackPointFeedBackWhenMouseUp(m_PointCentre, PointMouseUp, GlobeStatus.SelectMode);
            
            //清空追踪list
            int TrackPointListCount=m_TrackPointList.Count;
            for (int i = TrackPointListCount - 1; i > 0; i--)
            {
                if (m_TrackPointList[i].NewLineFeedback != null)
                    m_TrackPointList[i].NewLineFeedback = null;
            }
            m_TrackPointList.Clear();
            //刷新窗口图形
            //GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.Refresh();
        }
        private ICircularArc CircleFeedbackWhenMouseUp(IPoint pointMouseUp)
        {
            ICircularArc pCircularArc = m_CircleFeedback.Stop();
            m_CircleFeedback = null;
            return pCircularArc;
        }
       
        private void TrackPointFeedBackWhenMouseUp(IPoint pointCenter,IPoint pointMouseUp,EnumSelectMode selectMode)
        {
            //获得圆形
            IGeometry pGeometry = FunctionCommon.GetCircleGeometry(pointCenter, pointMouseUp);

            //按圆形选择
            GlobeStatus.Map.SelectByShape(pGeometry, null, false);

            //选择个数过多，放弃选择
            if (GlobeStatus.Map.SelectionCount > GlobeStatus.PixelMaxFeaturesSelect)
            {
                GlobeStatus.Map.ClearSelection();
                m_CircleFeedback = null;
                return;
            }

            double currentRadius = FunctionCommon.GetDistance2P(m_PointCentre, pointMouseUp);

            ISelection pSelection = GlobeStatus.Map.FeatureSelection;
            IEnumFeatureSetup pEnumFeatureSetup = pSelection as IEnumFeatureSetup;
            IEnumFeature pRnumFeature = pEnumFeatureSetup as IEnumFeature;
            pRnumFeature.Reset();

            IFeature pFeature = pRnumFeature.Next();
            while (pFeature != null)
            {
                string FeatureLayerName = FunctionCommon.GetLayerNameFromFeature(pFeature);
                if (!(GlobeStatus.CheckedPolyLines.Contains(FeatureLayerName)))
                    continue;

                //bool Changed = FeatureToCentre(pFeature.Shape, m_PointCentre, currentRadius, EnumPointEditModeVerticesToCenter.mostNearOne);
                //if (Changed)
                //    pFeature.Store();
                Tuple<int, int> PointIDPair = FunctionCommon.GetPointIDPairFromFeature(pFeature, pointCenter, currentRadius, selectMode);

                IPointCollection pPointCollection = pFeature.Shape as IPointCollection;    //图形几何点集
                if (PointIDPair.Item1 ==0 || PointIDPair.Item2 > 0)
                {
                    if (PointIDPair.Item1 ==0)
                        pPointCollection.UpdatePoint(0, pointCenter);
                    if (PointIDPair.Item2 > 0)
                        pPointCollection.UpdatePoint(PointIDPair.Item2, pointCenter);
                    pFeature.Store();
                }
                pFeature = pRnumFeature.Next();
            }
        }
        #endregion

        private IPoint PointSnapWhenMouseDown(IPoint pointCenter,int pixels)
        {
            IPoint PointSnap = pointCenter;
            return PointSnap;
        }
        private void PointSnapWhenMouseMove()
        {

        }
    }
}
