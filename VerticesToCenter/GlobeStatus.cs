using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
namespace VerticesToCenter
{
    public static class GlobeStatus
    {
        public static IMxDocument MxDocument
        {
            get
            {
                if (ArcMap.Application != null)
                    return ArcMap.Application.Document as IMxDocument;
                else
                    return null;
            }
        }
        public static IMap Map
        {
            get 
            {
                return MxDocument.FocusMap;
            }
        }
        public static IActiveView ActiveView
        {
            get
            {
                return Map as IActiveView;
            }
        }
        public static IEditor Editor
        {
            get
            {
                UID editorUID = new UID();
                editorUID.Value = "esriEditor.Editor";
                IEditor editor = ArcMap.Application.FindExtensionByCLSID(editorUID) as IEditor;
                return editor;
            }
        }
        public static IWorkspace EditWorkspace()
        {
            return Editor.EditWorkspace;
        }

        public static bool IsEditing
        {
            get
            {
                UID editorUID = new UID();
                editorUID.Value = "esriEditor.Editor";
                IEditor editor = ArcMap.Application.FindExtensionByCLSID(editorUID) as IEditor;
                if (editor != null)
                    return editor.EditState != esriEditState.esriStateNotEditing;
                else
                    return false;
            }
        }
        
        //LastPathName -- EditWorkspace
        private static string m_LastPathName="";
        public static string LastPathName
        {
            get { return m_LastPathName; }
        }
        public static void UpdateLastPathName(string name)
        {
            m_LastPathName = name;
        }

        //Option--SelectLayers
        public static PolyLinesVTC EditablePolyLines = new PolyLinesVTC();
        public static PolyLinesVTC CheckedPolyLines = new PolyLinesVTC();

        //Option--Setting
        private static bool m_CenterSnap = true;
        public static bool CenterSnap
        {
            get { return m_CenterSnap; }
        }
        public static void UpdateCenterSnap(bool centerSnap)
        {
            m_CenterSnap = centerSnap; 
        }

        private static EnumSelectMode m_SelectMod = EnumSelectMode.MostNearOne;
        public static EnumSelectMode SelectMode
        {
            get { return m_SelectMod; }
        }
        public static void UpdateSelectMode(EnumSelectMode selectMod)
        {
            m_SelectMod = selectMod;
        }

        private static int m_RadiusChangeLimit = 3;
        public static int RadiusChangeLimit
        {
            get { return m_RadiusChangeLimit; }
        }
        public static void UpdateRadiusChangeLimit(int radiusChangeLimit)
        {
            if (radiusChangeLimit < 1)
            {
                m_RadiusChangeLimit = 1;
                return;
            }
            if (radiusChangeLimit > 100)
            {
                m_RadiusChangeLimit = 100;
                return;
            }
            m_RadiusChangeLimit = radiusChangeLimit;
            
        }

        private static int m_MaxRadius = 500;
        public static int MaxRadius
        {
            get { return m_MaxRadius; }
        }
        public static void UpdateMaxRadius(int maxRadius)
        {
            if (maxRadius < 2)
            {
                m_MaxRadius = 2;
                return;
            }
            if (maxRadius > 1000)
            {
                m_MaxRadius = 1000;
                return;
            }
            m_MaxRadius = maxRadius;
        }

        private static int m_MaxFeaturesSelect = 10;
        public static int MaxFeaturesSelect
        {
            get { return m_MaxFeaturesSelect; }
        }
        public static void UpdateMaxFeaturesSelect(int maxFeaturesSelect)
        {
            if (maxFeaturesSelect < 1)
            {
                m_MaxFeaturesSelect = 1;
                return; 
            }
            if (maxFeaturesSelect > 100)
            {
                m_MaxFeaturesSelect = 100;
                return;
            }
            m_MaxFeaturesSelect = maxFeaturesSelect;
        }
    }

}
