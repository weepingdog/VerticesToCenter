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
        #region "1 System Event"
        public ToolVerticesToCenter()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;         
        }

        protected override void OnActivate()
        {
           
        }

        protected override bool OnDeactivate()
        {
            return base.OnDeactivate();
        }
        #endregion

        #region "2 Mouse Event"
        protected override void OnMouseDown(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            
        }

        protected override void OnMouseMove(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
            
        }

        protected override void OnMouseUp(ESRI.ArcGIS.Desktop.AddIns.Tool.MouseEventArgs arg)
        {
          
        }
        #endregion
    }

}
