using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
namespace VerticesToCenter
{
    public static class FunctionCommon
    {
        public static string GetNameFromLayer(IFeatureLayer featureLayer)
        {
            return featureLayer.Name;
        }
        public static IFeatureLayer GetFeatureLayerFromName(string featureClassName,PolyLinesVTC polylineVTC)
        {
            IFeatureLayer pFeatureLayer = null;
            foreach (IFeatureLayer featureLayer in polylineVTC.FeatureLayerList)
                if (featureClassName == FunctionCommon.GetNameFromLayer(featureLayer))
                    pFeatureLayer=featureLayer;
            return pFeatureLayer;
 
        }
        public static IList<IFeatureLayer> GetEditablePolyLines(IMap map)
        {
            IList<IFeatureLayer> pEditablePolyLines = new List<IFeatureLayer>();
            IEnumLayer pEnumLayer = map.get_Layers();
            pEnumLayer.Reset();
            ILayer pLayer = pEnumLayer.Next();
            while (pLayer != null)
            {
                IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                IDatasetEdit pDataEdit = pFeatureClass as IDatasetEdit;
                if (pDataEdit.IsBeingEdited() && pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    pEditablePolyLines.Add(pFeatureLayer);
                pLayer = pEnumLayer.Next();
            }
            return pEditablePolyLines;
        }

    }
}
