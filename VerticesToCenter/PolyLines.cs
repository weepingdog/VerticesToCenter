using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
namespace VerticesToCenter
{
    //public class PolyLinesVTC:IList<IFeatureLayer>
    public class PolyLines
    {
        private IList<IFeatureLayer> m_FeatureLayerList;
        public IList<IFeatureLayer> FeatureLayerList
        {
            get { return m_FeatureLayerList; }
        }

        public PolyLines()
        {
            m_FeatureLayerList = new List<IFeatureLayer>(); 
        }
        public PolyLines(IList<IFeatureLayer> featureLayerList)
        {
            m_FeatureLayerList = featureLayerList;
        }

        public int Count
        {
            get { return m_FeatureLayerList.Count; }
        }
        public void Add(IFeatureLayer featureLayer)
        {
            if (m_FeatureLayerList.Contains(featureLayer))
                return;
            else
                m_FeatureLayerList.Add(featureLayer);
        }
        public void UpdateFeatureLayerList(IList<IFeatureLayer> featureLayerList)
        {
            this.Clear();
            foreach (IFeatureLayer featureLayer in featureLayerList)
                this.Add(featureLayer);
        }        
        public void Remove(IFeatureLayer featureLayer)
        {
            if (m_FeatureLayerList.Contains(featureLayer))
                m_FeatureLayerList.Remove(featureLayer);
        }
        public void Clear()
        {
            m_FeatureLayerList.Clear();
        }

        public IFeatureLayer this[int index]
        {
            get { return m_FeatureLayerList[index]; }
            set { m_FeatureLayerList[index] = value; }
        }

        public bool Contains(IFeatureLayer featureLayer)
        {
            return m_FeatureLayerList.Contains(featureLayer);
        }
        public bool Contains(string name)
        {
            bool b_Contain = false;
            foreach (IFeatureLayer pFeatureLayer in m_FeatureLayerList)
            {
                string pFeatureClassName = FunctionCommon.GetNameFromFeatureLayer(pFeatureLayer);
                if (pFeatureClassName == name)
                {
                    b_Contain = true;
                    break;
                }
            }
            return b_Contain;
        }
        public IList<string> GetStringNames()
        {
            IList<string> Names = new List<string>();
            foreach (IFeatureLayer featureLayer in m_FeatureLayerList)
                Names.Add(FunctionCommon.GetNameFromFeatureLayer(featureLayer));
            
            return Names; 
        }
    }
}
