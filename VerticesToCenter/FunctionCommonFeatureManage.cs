using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace VerticesToCenter
{
    public static partial class FunctionCommon
    {
        //从要素图层获取图层名
        public static string GetLayerNameFromFeature(IFeature feature)
        {
            //Mark 手动修改层名可能会出现问题
            return feature.Class.AliasName;
        }
        //从要素图层获取图层名
        public static string GetNameFromFeatureLayer(IFeatureLayer featureLayer)
        {
            //Mark 手动修改层名可能会出现问题
            return featureLayer.Name;
        }
        //从要素图层列表里获取指定名称要素图层,仅第一个匹配要素图层
        public static IFeatureLayer GetFeatureLayerWithName(string name, IList<IFeatureLayer> featureLayerList)
        {
            IFeatureLayer pFeatureLayer = null;
            foreach (IFeatureLayer featureLayer in featureLayerList)
                if (name == FunctionCommon.GetNameFromFeatureLayer(featureLayer))
                {
                    pFeatureLayer = featureLayer;
                    break;
                }
            return pFeatureLayer;
        }

        //从地图内获取可编辑要素图层列表
        public static IList<IFeatureLayer> GetEditablePolyLines(IMap map)
        {
            IList<IFeatureLayer> pEditablePolyLines = new List<IFeatureLayer>();
            IEnumLayer pEnumLayer = map.get_Layers();
            pEnumLayer.Reset();
            ILayer pLayer = pEnumLayer.Next();
            while (pLayer != null)
            {
                //Mark 非要素图层是否有问题
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