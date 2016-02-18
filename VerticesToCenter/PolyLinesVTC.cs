﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
namespace VerticesToCenter
{
    public class PolyLinesVTC
    {
        private IList<IFeatureLayer> m_FeatureLayerList;
        public PolyLinesVTC()
        {
            m_FeatureLayerList = new List<IFeatureLayer>(); 
        }
        public PolyLinesVTC(IList<IFeatureLayer> featureLayerList)
        {
            m_FeatureLayerList = featureLayerList;
        }
        public IList<IFeatureLayer> FeatureLayerList
        {
            get { return m_FeatureLayerList; }
        }
        public void UpdateFeatureLayerList(IList<IFeatureLayer> featureLayerList)
        {
            this.Clear();
            foreach (IFeatureLayer featureLayer in featureLayerList)
                this.Add(featureLayer);
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
        public void Remove(IFeatureLayer featureLayer)
        {
            if (m_FeatureLayerList.Contains(featureLayer))
                m_FeatureLayerList.Remove(featureLayer);
        }
        public void Clear()
        {
            m_FeatureLayerList.Clear();
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
                string pFeatureClassName = FunctionCommon.GetNameFromLayer(pFeatureLayer);
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
                Names.Add(FunctionCommon.GetNameFromLayer(featureLayer));
            
            return Names; 
        }
    }
}