using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace VerticesToCenter
{
    public partial class FormOptionVerticesToCenter : Form
    {
        public FormOptionVerticesToCenter()
        {
            InitializeComponent();
            SelectLayersWhenFormStart();            
        }
        private void SelectLayersWhenFormStart()
        {
            checkedListBox_EditablePolyLineNames.Items.Clear();
            IList<IFeatureLayer> featureLayerList = GlobeStatus.EditablePolyLines.FeatureLayerList;
            foreach (IFeatureLayer featureLayer in featureLayerList)
            {
                bool isChecked = GlobeStatus.CheckedPolyLines.Contains(featureLayer);
                string name = FunctionCommon.GetNameFromLayer(featureLayer);
                checkedListBox_EditablePolyLineNames.Items.Add(name, isChecked);
            } 
        }

        private void button_SelectAll_Click(object sender, EventArgs e)
        {
            int itemCount = checkedListBox_EditablePolyLineNames.Items.Count;
            for (int i = 0; i < itemCount; i++)
                checkedListBox_EditablePolyLineNames.SetItemChecked(i, true);
        }

        private void button_SelectNone_Click(object sender, EventArgs e)
        {
            int itemCount = checkedListBox_EditablePolyLineNames.Items.Count;
            for (int i = 0; i < itemCount; i++)
                checkedListBox_EditablePolyLineNames.SetItemChecked(i, false);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {           
          
        }
        private void SelectLayersWhenOnClosing()
        {
            int itemsCount = checkedListBox_EditablePolyLineNames.Items.Count;
            for (int currentIndex = 0; currentIndex < itemsCount; currentIndex++)
            {
                bool currentIfChecked = checkedListBox_EditablePolyLineNames.GetItemChecked(currentIndex);
                //string currentItemName = checkedListBox_EditablePolyLineNames.GetItemText(currentIndex);
                string currentItemName = checkedListBox_EditablePolyLineNames.Items[currentIndex].ToString();
                IFeatureLayer pFeatureLayer = FunctionCommon.GetFeatureLayerFromName(currentItemName, GlobeStatus.EditablePolyLines);
                if (currentIfChecked && !GlobeStatus.CheckedPolyLines.Contains(pFeatureLayer))
                {
                    GlobeStatus.CheckedPolyLines.Add(pFeatureLayer);
                }
                if (!currentIfChecked && GlobeStatus.CheckedPolyLines.Contains(pFeatureLayer))
                    GlobeStatus.CheckedPolyLines.Remove(pFeatureLayer);
            } 
        }

        private void button_SelectLayers_Confirm_Click(object sender, EventArgs e)
        {
            SelectLayersWhenOnClosing();
        }

        private void button_Setting_Confirm_Click(object sender, EventArgs e)
        {

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
