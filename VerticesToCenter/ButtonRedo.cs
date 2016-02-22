using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;

namespace VerticesToCenter
{
    public class ButtonRedo : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonRedo()
        {
        }

        protected override void OnClick()
        {
            GlobeStatus.WorkspaceEdit.RedoEditOperation();
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            GlobeStatus.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        protected override void OnUpdate()
        {
            bool hasRedos = false;
            if (GlobeStatus.WorkspaceEdit != null)
                GlobeStatus.WorkspaceEdit.HasRedos(ref hasRedos);
            Enabled = (ArcMap.Application != null && GlobeStatus.IsEditing && hasRedos);
        }
    }
}
