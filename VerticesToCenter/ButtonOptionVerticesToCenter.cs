using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.ArcMapUI;
namespace VerticesToCenter
{
    public class ButtonOptionVerticesToCenter : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        private IEditEvents_Event m_editEvents = GlobeStatus.Editor as IEditEvents_Event;
        public ButtonOptionVerticesToCenter()
        {
            m_editEvents.OnStartEditing += new IEditEvents_OnStartEditingEventHandler(DoWhenStartEditing);
            //m_editEvents.OnStopEditing += new IEditEvents_OnStopEditingEventHandler(DoWhenStopEditing);
        }
        ~ButtonOptionVerticesToCenter()
        {
            m_editEvents.OnStartEditing -= new IEditEvents_OnStartEditingEventHandler(DoWhenStartEditing);
            //m_editEvents.OnStopEditing -= new IEditEvents_OnStopEditingEventHandler(DoWhenStopEditing);
        }
        public void DoWhenStartEditing()
        {
            //MessageBox.Show("hello");
            string CurrentPathName = GlobeStatus.Editor.EditWorkspace.PathName;
            if (CurrentPathName != GlobeStatus.LastPathName)
            {
                GlobeStatus.CheckedPolyLines.Clear();
                GlobeStatus.EditablePolyLines.Clear();
                IList<IFeatureLayer> FeatureLayerList = FunctionCommon.GetEditablePolyLines(GlobeStatus.Map);
                GlobeStatus.EditablePolyLines.UpdateFeatureLayerList(FeatureLayerList);
                GlobeStatus.UpdateLastPathName(CurrentPathName);
            }
            
        }
        //public void DoWhenStopEditing(bool justbool)
        //{                   
        //}
        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            FormOptionVerticesToCenter formVCOption = new FormOptionVerticesToCenter();
            formVCOption.Show();
        }
        protected override void OnUpdate()
        {
            //Enabled = ArcMap.Application != null;
            Enabled = (ArcMap.Application != null&&GlobeStatus.IsEditing);
        }
    }

}
