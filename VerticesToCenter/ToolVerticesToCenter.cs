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
        private double m_LastRadius=0;
        private IPoint m_PointCentre;

        private INewCircleFeedback m_CircleFeedback;    //3 跟踪圆

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

            //鼠标按下点作为圆心点
            IPoint PointMouseDown = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (PointMouseDown == null)
                return;
            m_PointCentre = PointMouseDown;

            //开始追踪圆
            if (m_CircleFeedback == null)
            {
                m_CircleFeedback = new NewCircleFeedbackClass();
                m_CircleFeedback.Display = GlobeStatus.ActiveView.ScreenDisplay;
                m_CircleFeedback.Start(m_PointCentre);
            }
            m_isMouseDown = true;
        }

        protected override void OnMouseMove(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            //鼠标未按下无效（要等同于拖曳操作）
            if (!m_isMouseDown)
                return;

            //移动到的点
            IPoint PointMouseMoveTo = GlobeStatus.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(arg.X, arg.Y);
            if (PointMouseMoveTo == null)
                return;

            //跟踪圆
            if (m_CircleFeedback != null)
                m_CircleFeedback.MoveTo(PointMouseMoveTo);

            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
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
            ICircularArc pCircularArc = m_CircleFeedback.Stop();
            m_CircleFeedback = null;

            //刷新窗口图形
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);          
        }
        #endregion
    }

}
