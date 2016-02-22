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
    public class ButtonOption : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        
        public ButtonOption()
        {
            GlobeStatus.EditEvents.OnStartEditing += new IEditEvents_OnStartEditingEventHandler(DoWhenStartEditing);
            GlobeStatus.EditEvents.OnStopEditing += new IEditEvents_OnStopEditingEventHandler(DoWhenStopEditing);
        }
        ~ButtonOption()
        {
            GlobeStatus.EditEvents.OnStartEditing -= new IEditEvents_OnStartEditingEventHandler(DoWhenStartEditing);
            GlobeStatus.EditEvents.OnStopEditing -= new IEditEvents_OnStopEditingEventHandler(DoWhenStopEditing);
        }
        public void DoWhenStartEditing()
        {
            string CurrentPathName = GlobeStatus.Editor.EditWorkspace.PathName;
            if (CurrentPathName != GlobeStatus.LastPathName)
            {
                GlobeStatus.CheckedPolyLines.Clear();
                GlobeStatus.EditablePolyLines.Clear();
                IList<IFeatureLayer> FeatureLayerList = FunctionCommon.GetEditablePolyLines(GlobeStatus.Map);
                GlobeStatus.EditablePolyLines.UpdateFeatureLayerList(FeatureLayerList);
                GlobeStatus.UpdateLastPathName(CurrentPathName);
            }
            //GlobeStatus.WorkspaceEdit.EnableUndoRedo();
            GlobeStatus.WorkspaceEdit.StartEditing(false);
        }
        public void DoWhenStopEditing(bool justbool)
        {
            GlobeStatus.WorkspaceEdit.StopEditing(true);    
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            FormOption formVTCOption = new FormOption();
            formVTCOption.Show();
        }
        protected override void OnUpdate()
        {
            //Enabled = ArcMap.Application != null;
            Enabled = (ArcMap.Application != null&&GlobeStatus.IsEditing);
        }
    }

}
