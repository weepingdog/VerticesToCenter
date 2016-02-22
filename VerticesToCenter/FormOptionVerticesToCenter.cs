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
            UpdateComboBoxSelectMode();
            SelectLayersTapControlWhenFormStart();
            SettingTapControlWhenFormStart();
        }

        private void SelectLayersTapControlWhenFormStart()
        {
            checkedListBox_EditablePolyLines.Items.Clear();
            IList<IFeatureLayer> featureLayerList = GlobeStatus.EditablePolyLines.FeatureLayerList;
            foreach (IFeatureLayer featureLayer in featureLayerList)
            {
                bool isChecked = GlobeStatus.CheckedPolyLines.Contains(featureLayer);
                string name = FunctionCommon.GetNameFromFeatureLayer(featureLayer);
                checkedListBox_EditablePolyLines.Items.Add(name, isChecked);
            } 
        }

        private void SettingTapControlWhenFormStart()
        {
            checkBox_CenterSnap.Checked = GlobeStatus.CenterSnap;
            comboBox_SelectMode.SelectedIndex = (int)(GlobeStatus.SelectMode);
            numericUpDown_RadiusChangeLimit.Value = GlobeStatus.PixelRadiusChangeLimit;
            numericUpDown_MaxRadius.Value = GlobeStatus.PixelMaxRadius;
            numericUpDown_MaxFeaturesSelect.Value = GlobeStatus.MaxFeaturesSelect;  
        }

        private void UpdateComboBoxSelectMode()
        {
            comboBox_SelectMode.Items.Clear();
            foreach(object item in Enum.GetNames(typeof(EnumSelectMode)))
                comboBox_SelectMode.Items.Add(item);        
        }

        private void button_SelectAll_Click(object sender, EventArgs e)
        {
            int itemCount = checkedListBox_EditablePolyLines.Items.Count;
            for (int i = 0; i < itemCount; i++)
                checkedListBox_EditablePolyLines.SetItemChecked(i, true);
        }

        private void button_SelectNone_Click(object sender, EventArgs e)
        {
            int itemCount = checkedListBox_EditablePolyLines.Items.Count;
            for (int i = 0; i < itemCount; i++)
                checkedListBox_EditablePolyLines.SetItemChecked(i, false);
        }        

        private void button_SelectLayers_Confirm_Click(object sender, EventArgs e)
        {
            SelectLayersTabControlWhenConfirm();
        }

        private void button_Setting_Confirm_Click(object sender, EventArgs e)
        {
            SettingTabControlWhenConfirm();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SelectLayersTabControlWhenConfirm();
            SettingTabControlWhenConfirm();
            this.Close();
        }

        private void SelectLayersTabControlWhenConfirm()
        {
            int itemsCount = checkedListBox_EditablePolyLines.Items.Count;
            for (int currentIndex = 0; currentIndex < itemsCount; currentIndex++)
            {
                bool currentIfChecked = checkedListBox_EditablePolyLines.GetItemChecked(currentIndex);
                //string currentItemName = checkedListBox_EditablePolyLineNames.GetItemText(currentIndex);
                string currentItemName = checkedListBox_EditablePolyLines.Items[currentIndex].ToString();
                IFeatureLayer pFeatureLayer = FunctionCommon.GetFeatureLayerWithName(currentItemName, GlobeStatus.EditablePolyLines.FeatureLayerList);
                if (currentIfChecked && !GlobeStatus.CheckedPolyLines.Contains(pFeatureLayer))
                {
                    GlobeStatus.CheckedPolyLines.Add(pFeatureLayer);
                }
                if (!currentIfChecked && GlobeStatus.CheckedPolyLines.Contains(pFeatureLayer))
                    GlobeStatus.CheckedPolyLines.Remove(pFeatureLayer);
            }
        }

        private void SettingTabControlWhenConfirm()
        {
            GlobeStatus.UpdateCenterSnap(checkBox_CenterSnap.Checked);
            GlobeStatus.UpdateSelectMode((EnumSelectMode)comboBox_SelectMode.SelectedIndex);
            GlobeStatus.UpdatePixelRadiusChangeLimit((int)numericUpDown_RadiusChangeLimit.Value);
            GlobeStatus.UpdatePixelMaxRadius((int)numericUpDown_MaxRadius.Value);
            GlobeStatus.UpdateMaxFeaturesSelect((int)numericUpDown_MaxFeaturesSelect.Value);
        }

        private void button_SettingDefault_Click(object sender, EventArgs e)
        {
            GlobeStatus.UpdateCenterSnap(true);
            GlobeStatus.UpdateSelectMode(EnumSelectMode.MostNearOne);
            GlobeStatus.UpdatePixelRadiusChangeLimit(1);
            GlobeStatus.UpdatePixelMaxRadius(200);
            GlobeStatus.UpdateMaxFeaturesSelect(20);
            SettingTapControlWhenFormStart();
        }
    }
}
