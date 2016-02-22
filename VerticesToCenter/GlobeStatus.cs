using ESRI.ArcGIS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Editor;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
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
        
        public static IEditEvents_Event EditEvents
        {
            get { return GlobeStatus.Editor as IEditEvents_Event; }
        }

        public static IWorkspace Workspace
        {
            get{ return Editor.EditWorkspace; }
        }
        public static IWorkspaceEdit WorkspaceEdit
        {
            get { return (IWorkspaceEdit)Editor.EditWorkspace; }
        }

        //public static ICommandItem UndoICommandItem
        //{
        //    get { return FunctionCommon.GetCommandOnToolbar(ArcMap.Application, "StandardToolBar", ""); }
        //}
        public static ICommandBar StandardToolBar
        {
            get { return FunctionCommon.GetToolbarByName(ArcMap.Application, "esriArcMapUI.StandardToolBar"); }
        }


        public static ICommandItem UndoCommand 
        {
            get
            {
                UID uid = new UIDClass();
                //uid.Value = "{FBF8C3FB-0480-11D2-8D21-080009EE4E51}";
                uid.Value = "esriArcMapUI.MxEditMenuItem";
                uid.SubType = 1;
                ICommandItem undoCommand = StandardToolBar.Find(uid, false);
                return undoCommand;
                
                 
            }
        }

        public static ICommandItem RedoCommand
        {
            get
            {
                UID uid = new UIDClass();
                //uid.Value = "{FBF8C3FB-0480-11D2-8D21-080009EE4E51}";
                uid.Value = "esriArcMapUI.MxEditMenuItem";
                uid.SubType = 2;
                ICommandItem redoCommand = StandardToolBar.Find(uid, false);
                return redoCommand;
            }
        }

        //public static 
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
        
        public static double MapUnit
        {
            get { return FunctionCommon.GetMapUnit(ActiveView); }
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
        public static ToolSetting Setting=new ToolSetting();        
    }       

    
    public class ToolSetting
    {

        public ToolSetting()
        {
            //默认构造函数
            m_CenterSnap = true;
            m_SelectMod = EnumSelectMode.MostNearOne;
            m_PixelRadiusChangeLimit = 1;
            m_PixelMaxRadius = 200;
            m_MaxFeaturesSelect = 20;
 
        }
        public ToolSetting(ToolSetting toolSetting)
        {
            m_CenterSnap = toolSetting.CenterSnap;
            m_SelectMod = toolSetting.SelectMode;
            m_PixelRadiusChangeLimit = toolSetting.PixelRadiusChangeLimit;
            m_PixelMaxRadius = toolSetting.PixelMaxRadius;
            m_MaxFeaturesSelect = toolSetting.MaxFeaturesSelect; 
        }
        private bool m_CenterSnap;
        public bool CenterSnap
        {
            get { return m_CenterSnap; }
        }
        public void UpdateCenterSnap(bool centerSnap)
        {
            m_CenterSnap = centerSnap;
        }

        private EnumSelectMode m_SelectMod;
        public EnumSelectMode SelectMode
        {
            get { return m_SelectMod; }
        }
        public void UpdateSelectMode(EnumSelectMode selectMod)
        {
            m_SelectMod = selectMod;
        }

        private int m_PixelRadiusChangeLimit;
        public int PixelRadiusChangeLimit
        {
            get { return m_PixelRadiusChangeLimit; }
        }
        public void UpdatePixelRadiusChangeLimit(int pixelRadiusChangeLimit)
        {
            if (pixelRadiusChangeLimit < 1)
            {
                m_PixelRadiusChangeLimit = 1;
                return;
            }
            if (pixelRadiusChangeLimit > 100)
            {
                m_PixelRadiusChangeLimit = 100;
                return;
            }
            m_PixelRadiusChangeLimit = pixelRadiusChangeLimit;

        }

        private int m_PixelMaxRadius;
        public int PixelMaxRadius
        {
            get { return m_PixelMaxRadius; }
        }
        public void UpdatePixelMaxRadius(int PixelMaxRadius)
        {
            if (PixelMaxRadius < 2)
            {
                m_PixelMaxRadius = 2;
                return;
            }
            if (PixelMaxRadius > 1000)
            {
                m_PixelMaxRadius = 1000;
                return;
            }
            m_PixelMaxRadius = PixelMaxRadius;
        }

        private int m_MaxFeaturesSelect;
        public int MaxFeaturesSelect
        {
            get { return m_MaxFeaturesSelect; }
        }
        public void UpdateMaxFeaturesSelect(int maxFeaturesSelect)
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
