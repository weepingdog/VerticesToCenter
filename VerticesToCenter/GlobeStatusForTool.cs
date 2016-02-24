using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace VerticesToCenter
{
    public static partial class GlobeStatus
    {
        //LastPathName -- EditWorkspace
        private static string m_LastPathName = "";
        public static string LastPathName
        {
            get { return m_LastPathName; }
            set { m_LastPathName = value; }
        }

        //Option--SelectLayers
        public static PolyLines EditablePolyLines = new PolyLines();
        public static PolyLines CheckedPolyLines = new PolyLines();

        //Option--Setting
        public static VerticesToCenterSetting Setting = new VerticesToCenterSetting();
    }
}