﻿using System;
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
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();
            UpdateComboBoxSnapKey();
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
            checkBox_CenterSnap.Checked = GlobeStatus.Setting.CenterSnap;
            comboBox_KeySnapSwitch.SelectedIndex = FunctionCommon.GetIndexFromSnapKeyDown(GlobeStatus.Setting.KeySnapSwitch);
            numericUpDown_PixelSnap.Value = GlobeStatus.Setting.PixelSnap;
            comboBox_SelectMode.SelectedIndex = (int)(GlobeStatus.Setting.SelectMode);
            numericUpDown_RadiusChangeLimit.Value = GlobeStatus.Setting.PixelRadiusChangeLimit;
            numericUpDown_MaxRadius.Value = GlobeStatus.Setting.PixelMaxRadius;
            numericUpDown_MaxFeaturesSelect.Value = GlobeStatus.Setting.MaxFeaturesSelect;  
        }

        private void UpdateComboBoxSnapKey()
        {
            comboBox_KeySnapSwitch.Items.Clear();
            comboBox_KeySnapSwitch.Items.Add(Keys.ControlKey);
            comboBox_KeySnapSwitch.Items.Add(Keys.LControlKey);
            comboBox_KeySnapSwitch.Items.Add(Keys.RControlKey);
            comboBox_KeySnapSwitch.Items.Add(Keys.ShiftKey);
            comboBox_KeySnapSwitch.Items.Add(Keys.LShiftKey);
            comboBox_KeySnapSwitch.Items.Add(Keys.RShiftKey);            
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
            GlobeStatus.Setting.CenterSnap = checkBox_CenterSnap.Checked;
            GlobeStatus.Setting.KeySnapSwitch = FunctionCommon.GetSnapKeyDownFromIndex(comboBox_KeySnapSwitch.SelectedIndex);
            GlobeStatus.Setting.PixelSnap = (int)numericUpDown_PixelSnap.Value;
            GlobeStatus.Setting.SelectMode = (EnumSelectMode)comboBox_SelectMode.SelectedIndex;
            GlobeStatus.Setting.PixelRadiusChangeLimit = (int)numericUpDown_RadiusChangeLimit.Value;
            GlobeStatus.Setting.PixelMaxRadius = (int)numericUpDown_MaxRadius.Value;
            GlobeStatus.Setting.MaxFeaturesSelect = (int)numericUpDown_MaxFeaturesSelect.Value;
        }

        private void button_SettingDefault_Click(object sender, EventArgs e)
        {
            GlobeStatus.Setting.CenterSnap = DefaultVerticesToCenterSetting.CenterSnap;
            GlobeStatus.Setting.KeySnapSwitch = DefaultVerticesToCenterSetting.KeySnapSwitch;
            GlobeStatus.Setting.PixelSnap = DefaultVerticesToCenterSetting.PixelSnap;
            GlobeStatus.Setting.SelectMode = DefaultVerticesToCenterSetting.SelectMode;
            GlobeStatus.Setting.PixelRadiusChangeLimit = DefaultVerticesToCenterSetting.PixelRadiusChangeLimit;
            GlobeStatus.Setting.PixelMaxRadius = DefaultVerticesToCenterSetting.PixelMaxRadius;
            GlobeStatus.Setting.MaxFeaturesSelect = DefaultVerticesToCenterSetting.MaxFeaturesSelect;
            
            SettingTapControlWhenFormStart();
        }
    }
}
