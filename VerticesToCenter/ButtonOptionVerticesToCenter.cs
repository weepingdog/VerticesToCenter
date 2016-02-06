using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ArcMapUI;
namespace VerticesToCenter
{
    public class ButtonOptionVerticesToCenter : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public ButtonOptionVerticesToCenter()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            
        }
        protected override void OnUpdate()
        {
            //Enabled = ArcMap.Application != null;
            Enabled = (ArcMap.Application != null);
        }
    }

}
