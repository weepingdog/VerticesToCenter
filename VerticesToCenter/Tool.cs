using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;

namespace VerticesToCenter
{
    public class Tool : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        private bool m_isMouseDown = false;
        private IPoint m_PointCentre;
        private IPoint m_PointMouseMoveTo;
        
        private INewCircleFeedback m_CircleFeedback;    //3 跟踪圆

        //private int m_LastSelectFeatureCount = 0;
        private double m_LastRadius = 0;        
        private IList<TrackPoint> m_TrackPointList = new List<TrackPoint>();

        #region "1 System Event"
        public Tool()
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

            IPoint PointMouseDown = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (PointMouseDown == null)
                return;

            if (GlobeStatus.Setting.CenterSnap) //若开启了圆心捕捉
            {
                m_PointCentre = PointSnapWhenMouseDown(PointMouseDown, GlobeStatus.Setting.PixelRadiusChangeLimit);
            }
            else
            {
                m_PointCentre = PointMouseDown;
            }

            //开始追踪圆
            CircleFeedBackWhenMouseDown(m_PointCentre);

            FeatureSelectWhenMouseDown(m_PointCentre);

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
        private void FeatureSelectWhenMouseDown(IPoint pointCentre)
        {
            m_TrackPointList.Clear();
        }

        protected override void OnMouseMove(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            //移动到的点
            m_PointMouseMoveTo = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (m_PointMouseMoveTo == null)
                return;

            if (!m_isMouseDown) //鼠标未按下无仅提示捕捉圆心点(在开启捕捉情况下)
            {
                if (GlobeStatus.Setting.CenterSnap)
                    PointSnapWhenMouseMove();
                return; 
            }
            
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            
            //跟踪圆
            CircleFeedBackWhenMouseMove(m_PointMouseMoveTo);
           
            //追踪多个待移动的点
            FeatureSelectWhenMouseMove(m_PointCentre, m_PointMouseMoveTo, GlobeStatus.Setting.SelectMode);

            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            //GlobeStatus.ActiveView.Refresh();
        }
        private void CircleFeedBackWhenMouseMove(IPoint pointMouseMoveTo)
        {
            double currentRadius = FunctionCommon.GetDistance2P(m_PointCentre, pointMouseMoveTo);

            //1 选择半径太大，不响应
            if (currentRadius > GlobeStatus.Setting.PixelMaxRadius * GlobeStatus.MapUnit)
            {
                //GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                return;
            }
            if (m_CircleFeedback != null)
                m_CircleFeedback.MoveTo(pointMouseMoveTo);
        }     
        private void FeatureSelectWhenMouseMove(IPoint pointCentre, IPoint pointMouseMoveTo, EnumSelectMode SelectMode)
        {
            double currentRadius = FunctionCommon.GetDistance2P(m_PointCentre, pointMouseMoveTo);

            //1 选择半径太大，不响应
            if (currentRadius > GlobeStatus.Setting.PixelMaxRadius * GlobeStatus.MapUnit)
            {
                return;
            }

            //2 变化距离太小，不响应
            double distanceChange = currentRadius - m_LastRadius;
            if (Math.Abs(distanceChange) < GlobeStatus.Setting.PixelRadiusChangeLimit * GlobeStatus.MapUnit)
            {
                return;
            }

            //3 开始选择
            IGeometry pGeometry = FunctionCommon.GetCircleGeometry(m_PointCentre, currentRadius);
            ISelectionEnvironment env = new SelectionEnvironmentClass();
            env.CombinationMethod = esriSelectionResultEnum.esriSelectionResultNew;
            GlobeStatus.Map.SelectByShape(pGeometry, env, false);    
        }

        protected override void OnMouseUp(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            //鼠标不再按下
            m_isMouseDown = false;

            //鼠标放开时的点
            //IPoint PointMouseUp = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (m_PointMouseMoveTo == null)
            {
                GlobeStatus.ActiveView.Refresh();
                return;
            }

            //追踪圆停止
            CircleFeedbackWhenMouseUp(m_PointMouseMoveTo);            

            //追踪多点停止，修改几何
            FeatureSelectWhenMouseUp(m_PointCentre, m_PointMouseMoveTo, GlobeStatus.Setting.SelectMode);
            
            //刷新窗口图形
            //GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.Refresh();

            ICommandItem undoCommand = GlobeStatus.UndoCommand;
            ICommandItem redoCommand = GlobeStatus.RedoCommand;
            undoCommand.Execute();
            redoCommand.Execute();

            m_TrackPointList.Clear();
        }
        private void CircleFeedbackWhenMouseUp(IPoint pointMouseUp)
        {
            if(m_CircleFeedback!=null)
            {
                m_CircleFeedback.Stop();
                m_CircleFeedback = null;
            }
        }
        private void FeatureSelectWhenMouseUp(IPoint pointCenter, IPoint pointMouseUp, EnumSelectMode selectMode)
        {        
            //选择个数过多，放弃选择
            if (GlobeStatus.Map.SelectionCount > GlobeStatus.Setting.MaxFeaturesSelect)
            {
                //GlobeStatus.Map.ClearSelection();
                MessageBox.Show("Too many features selected");
                return;
            }

            double currentRadius = FunctionCommon.GetDistance2P(m_PointCentre, pointMouseUp);

            ISelection pSelection = GlobeStatus.Map.FeatureSelection;
            IEnumFeatureSetup pEnumFeatureSetup = pSelection as IEnumFeatureSetup;
            IEnumFeature pRnumFeature = pEnumFeatureSetup as IEnumFeature;
            pRnumFeature.Reset();
            IFeature pFeature = pRnumFeature.Next();
            GlobeStatus.WorkspaceEdit.StartEditOperation();
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
                    pFeature.Shape = (IGeometry)pPointCollection;
                    pFeature.Store();                    
                }
                pFeature = pRnumFeature.Next();
            }
            GlobeStatus.WorkspaceEdit.StopEditOperation();
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
