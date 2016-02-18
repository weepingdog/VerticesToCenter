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
        public static string GetNameFromFeatureLayer(IFeatureLayer featureLayer)
        {
            //Mark 手动修改层名可能会出现问题
            return featureLayer.Name;
        }

        public static IFeatureLayer GetFeatureLayerWithName(string name, IList<IFeatureLayer> featureLayerList)
        {
            IFeatureLayer pFeatureLayer = null;
            foreach (IFeatureLayer featureLayer in featureLayerList)
                if (name == FunctionCommon.GetNameFromFeatureLayer(featureLayer))
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
    public enum EnumSelectMode
    {
        MostNearOne = 0,//最近点
        OnlyFirst = 1,//首点 ID=0-，实际的末点
        OnlyLast = 2, //末点，ID=N-1，实际的首点
        BothFirstAndLast = 3,//两端的点
    }
}
