using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace VerticesToCenter
{
    public class ButtonUndo : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonUndo()
        {
        }

        protected override void OnClick()
        {
        }

        protected override void OnUpdate()
        {

            Enabled = (ArcMap.Application != null && GlobeStatus.IsEditing);
        }
    }
}
