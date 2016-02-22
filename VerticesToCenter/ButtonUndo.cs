using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;

namespace VerticesToCenter
{
    public class ButtonUndo : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonUndo()
        {
        }

        protected override void OnClick()
        {
            GlobeStatus.WorkspaceEdit.UndoEditOperation();
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        protected override void OnUpdate()
        {
            bool hasUndos = false;
            if(GlobeStatus.WorkspaceEdit!=null)
                GlobeStatus.WorkspaceEdit.HasUndos(ref hasUndos);
            Enabled = (ArcMap.Application != null && GlobeStatus.IsEditing && hasUndos);
        }
    }
}
