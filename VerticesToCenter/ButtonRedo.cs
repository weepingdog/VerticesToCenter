using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace VerticesToCenter
{
    public class ButtonRedo : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonRedo()
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
