using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.ArcMapUI;
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
            get { return MxDocument.FocusMap; }
        }
        public static IActiveView ActiveView
        {
            get { return Map as IActiveView; }
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
        public static IGraphicsContainer GraphicsContainer
        {
            get { return Map as IGraphicsContainer; }
        }

        //private static AxMapControl m_axMapControl;
        //public static AxMapControl axMapControl
        //{
        //    get 
        //    {
        //        return m_axMapControl;
        //    }
        //}
        //public static void UpdateAxMapControl(AxMapControl amc)
        //{
        //    m_axMapControl=amc;
        //}

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
    }   
}
