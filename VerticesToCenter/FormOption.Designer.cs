namespace VerticesToCenter
{
    partial class FormOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOption));
            this.checkedListBox_EditablePolyLines = new System.Windows.Forms.CheckedListBox();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_SelectNone = new System.Windows.Forms.Button();
            this.tabControl_Option = new System.Windows.Forms.TabControl();
            this.tabPage_SelectLayers = new System.Windows.Forms.TabPage();
            this.button_SelectLayers_Confirm = new System.Windows.Forms.Button();
            this.tabPage_Setting = new System.Windows.Forms.TabPage();
            this.groupBox_SnapOption = new System.Windows.Forms.GroupBox();
            this.checkBox_CenterSnap = new System.Windows.Forms.CheckBox();
            this.numericUpDown_PixelSnap = new System.Windows.Forms.NumericUpDown();
            this.label_PixelSnap = new System.Windows.Forms.Label();
            this.label_KeySnapSwitch = new System.Windows.Forms.Label();
            this.comboBox_KeySnapSwitch = new System.Windows.Forms.ComboBox();
            this.button_SettingDefault = new System.Windows.Forms.Button();
            this.button_Setting_Confirm = new System.Windows.Forms.Button();
            this.numericUpDown_MaxFeaturesSelect = new System.Windows.Forms.NumericUpDown();
            this.label_MaxFeaturesSelect = new System.Windows.Forms.Label();
            this.groupBox_Pixel = new System.Windows.Forms.GroupBox();
            this.numericUpDown_MaxRadius = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_RadiusChangeLimit = new System.Windows.Forms.NumericUpDown();
            this.label_MaxRadius = new System.Windows.Forms.Label();
            this.label_RadiusChangeLimit = new System.Windows.Forms.Label();
            this.label_SelectMode = new System.Windows.Forms.Label();
            this.comboBox_SelectMode = new System.Windows.Forms.ComboBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.tabControl_Option.SuspendLayout();
            this.tabPage_SelectLayers.SuspendLayout();
            this.tabPage_Setting.SuspendLayout();
            this.groupBox_SnapOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PixelSnap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxFeaturesSelect)).BeginInit();
            this.groupBox_Pixel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RadiusChangeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox_EditablePolyLines
            // 
            resources.ApplyResources(this.checkedListBox_EditablePolyLines, "checkedListBox_EditablePolyLines");
            this.checkedListBox_EditablePolyLines.CheckOnClick = true;
            this.checkedListBox_EditablePolyLines.FormattingEnabled = true;
            this.checkedListBox_EditablePolyLines.Name = "checkedListBox_EditablePolyLines";
            // 
            // button_SelectAll
            // 
            resources.ApplyResources(this.button_SelectAll, "button_SelectAll");
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // button_SelectNone
            // 
            resources.ApplyResources(this.button_SelectNone, "button_SelectNone");
            this.button_SelectNone.Name = "button_SelectNone";
            this.button_SelectNone.UseVisualStyleBackColor = true;
            this.button_SelectNone.Click += new System.EventHandler(this.button_SelectNone_Click);
            // 
            // tabControl_Option
            // 
            resources.ApplyResources(this.tabControl_Option, "tabControl_Option");
            this.tabControl_Option.Controls.Add(this.tabPage_SelectLayers);
            this.tabControl_Option.Controls.Add(this.tabPage_Setting);
            this.tabControl_Option.Name = "tabControl_Option";
            this.tabControl_Option.SelectedIndex = 0;
            // 
            // tabPage_SelectLayers
            // 
            resources.ApplyResources(this.tabPage_SelectLayers, "tabPage_SelectLayers");
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectLayers_Confirm);
            this.tabPage_SelectLayers.Controls.Add(this.checkedListBox_EditablePolyLines);
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectNone);
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectAll);
            this.tabPage_SelectLayers.Name = "tabPage_SelectLayers";
            this.tabPage_SelectLayers.UseVisualStyleBackColor = true;
            // 
            // button_SelectLayers_Confirm
            // 
            resources.ApplyResources(this.button_SelectLayers_Confirm, "button_SelectLayers_Confirm");
            this.button_SelectLayers_Confirm.Name = "button_SelectLayers_Confirm";
            this.button_SelectLayers_Confirm.UseVisualStyleBackColor = true;
            this.button_SelectLayers_Confirm.Click += new System.EventHandler(this.button_SelectLayers_Confirm_Click);
            // 
            // tabPage_Setting
            // 
            resources.ApplyResources(this.tabPage_Setting, "tabPage_Setting");
            this.tabPage_Setting.Controls.Add(this.groupBox_SnapOption);
            this.tabPage_Setting.Controls.Add(this.button_SettingDefault);
            this.tabPage_Setting.Controls.Add(this.button_Setting_Confirm);
            this.tabPage_Setting.Controls.Add(this.numericUpDown_MaxFeaturesSelect);
            this.tabPage_Setting.Controls.Add(this.label_MaxFeaturesSelect);
            this.tabPage_Setting.Controls.Add(this.groupBox_Pixel);
            this.tabPage_Setting.Controls.Add(this.label_SelectMode);
            this.tabPage_Setting.Controls.Add(this.comboBox_SelectMode);
            this.tabPage_Setting.Name = "tabPage_Setting";
            this.tabPage_Setting.UseVisualStyleBackColor = true;
            // 
            // groupBox_SnapOption
            // 
            resources.ApplyResources(this.groupBox_SnapOption, "groupBox_SnapOption");
            this.groupBox_SnapOption.Controls.Add(this.checkBox_CenterSnap);
            this.groupBox_SnapOption.Controls.Add(this.numericUpDown_PixelSnap);
            this.groupBox_SnapOption.Controls.Add(this.label_PixelSnap);
            this.groupBox_SnapOption.Controls.Add(this.label_KeySnapSwitch);
            this.groupBox_SnapOption.Controls.Add(this.comboBox_KeySnapSwitch);
            this.groupBox_SnapOption.Name = "groupBox_SnapOption";
            this.groupBox_SnapOption.TabStop = false;
            // 
            // checkBox_CenterSnap
            // 
            resources.ApplyResources(this.checkBox_CenterSnap, "checkBox_CenterSnap");
            this.checkBox_CenterSnap.Name = "checkBox_CenterSnap";
            this.checkBox_CenterSnap.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_PixelSnap
            // 
            resources.ApplyResources(this.numericUpDown_PixelSnap, "numericUpDown_PixelSnap");
            this.numericUpDown_PixelSnap.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_PixelSnap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_PixelSnap.Name = "numericUpDown_PixelSnap";
            this.numericUpDown_PixelSnap.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label_PixelSnap
            // 
            resources.ApplyResources(this.label_PixelSnap, "label_PixelSnap");
            this.label_PixelSnap.Name = "label_PixelSnap";
            // 
            // label_KeySnapSwitch
            // 
            resources.ApplyResources(this.label_KeySnapSwitch, "label_KeySnapSwitch");
            this.label_KeySnapSwitch.Name = "label_KeySnapSwitch";
            // 
            // comboBox_KeySnapSwitch
            // 
            resources.ApplyResources(this.comboBox_KeySnapSwitch, "comboBox_KeySnapSwitch");
            this.comboBox_KeySnapSwitch.FormattingEnabled = true;
            this.comboBox_KeySnapSwitch.Name = "comboBox_KeySnapSwitch";
            // 
            // button_SettingDefault
            // 
            resources.ApplyResources(this.button_SettingDefault, "button_SettingDefault");
            this.button_SettingDefault.Name = "button_SettingDefault";
            this.button_SettingDefault.UseVisualStyleBackColor = true;
            this.button_SettingDefault.Click += new System.EventHandler(this.button_SettingDefault_Click);
            // 
            // button_Setting_Confirm
            // 
            resources.ApplyResources(this.button_Setting_Confirm, "button_Setting_Confirm");
            this.button_Setting_Confirm.Name = "button_Setting_Confirm";
            this.button_Setting_Confirm.UseVisualStyleBackColor = true;
            this.button_Setting_Confirm.Click += new System.EventHandler(this.button_Setting_Confirm_Click);
            // 
            // numericUpDown_MaxFeaturesSelect
            // 
            resources.ApplyResources(this.numericUpDown_MaxFeaturesSelect, "numericUpDown_MaxFeaturesSelect");
            this.numericUpDown_MaxFeaturesSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_MaxFeaturesSelect.Name = "numericUpDown_MaxFeaturesSelect";
            this.numericUpDown_MaxFeaturesSelect.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label_MaxFeaturesSelect
            // 
            resources.ApplyResources(this.label_MaxFeaturesSelect, "label_MaxFeaturesSelect");
            this.label_MaxFeaturesSelect.Name = "label_MaxFeaturesSelect";
            // 
            // groupBox_Pixel
            // 
            resources.ApplyResources(this.groupBox_Pixel, "groupBox_Pixel");
            this.groupBox_Pixel.Controls.Add(this.numericUpDown_MaxRadius);
            this.groupBox_Pixel.Controls.Add(this.numericUpDown_RadiusChangeLimit);
            this.groupBox_Pixel.Controls.Add(this.label_MaxRadius);
            this.groupBox_Pixel.Controls.Add(this.label_RadiusChangeLimit);
            this.groupBox_Pixel.Name = "groupBox_Pixel";
            this.groupBox_Pixel.TabStop = false;
            // 
            // numericUpDown_MaxRadius
            // 
            resources.ApplyResources(this.numericUpDown_MaxRadius, "numericUpDown_MaxRadius");
            this.numericUpDown_MaxRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_MaxRadius.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_MaxRadius.Name = "numericUpDown_MaxRadius";
            this.numericUpDown_MaxRadius.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDown_RadiusChangeLimit
            // 
            resources.ApplyResources(this.numericUpDown_RadiusChangeLimit, "numericUpDown_RadiusChangeLimit");
            this.numericUpDown_RadiusChangeLimit.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_RadiusChangeLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_RadiusChangeLimit.Name = "numericUpDown_RadiusChangeLimit";
            this.numericUpDown_RadiusChangeLimit.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label_MaxRadius
            // 
            resources.ApplyResources(this.label_MaxRadius, "label_MaxRadius");
            this.label_MaxRadius.Name = "label_MaxRadius";
            // 
            // label_RadiusChangeLimit
            // 
            resources.ApplyResources(this.label_RadiusChangeLimit, "label_RadiusChangeLimit");
            this.label_RadiusChangeLimit.Name = "label_RadiusChangeLimit";
            // 
            // label_SelectMode
            // 
            resources.ApplyResources(this.label_SelectMode, "label_SelectMode");
            this.label_SelectMode.Name = "label_SelectMode";
            // 
            // comboBox_SelectMode
            // 
            resources.ApplyResources(this.comboBox_SelectMode, "comboBox_SelectMode");
            this.comboBox_SelectMode.FormattingEnabled = true;
            this.comboBox_SelectMode.Name = "comboBox_SelectMode";
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            this.button_OK.Name = "button_OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // FormOption
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.tabControl_Option);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOption";
            this.tabControl_Option.ResumeLayout(false);
            this.tabPage_SelectLayers.ResumeLayout(false);
            this.tabPage_Setting.ResumeLayout(false);
            this.tabPage_Setting.PerformLayout();
            this.groupBox_SnapOption.ResumeLayout(false);
            this.groupBox_SnapOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PixelSnap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxFeaturesSelect)).EndInit();
            this.groupBox_Pixel.ResumeLayout(false);
            this.groupBox_Pixel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RadiusChangeLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_EditablePolyLines;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.Button button_SelectNone;
        private System.Windows.Forms.TabControl tabControl_Option;
        private System.Windows.Forms.TabPage tabPage_SelectLayers;
        private System.Windows.Forms.TabPage tabPage_Setting;
        private System.Windows.Forms.CheckBox checkBox_CenterSnap;
        private System.Windows.Forms.Label label_SelectMode;
        private System.Windows.Forms.ComboBox comboBox_SelectMode;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxFeaturesSelect;
        private System.Windows.Forms.Label label_MaxFeaturesSelect;
        private System.Windows.Forms.GroupBox groupBox_Pixel;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxRadius;
        private System.Windows.Forms.NumericUpDown numericUpDown_RadiusChangeLimit;
        private System.Windows.Forms.Label label_MaxRadius;
        private System.Windows.Forms.Label label_RadiusChangeLimit;
        private System.Windows.Forms.Button button_SelectLayers_Confirm;
        private System.Windows.Forms.Button button_Setting_Confirm;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_SettingDefault;
        private System.Windows.Forms.Label label_KeySnapSwitch;
        private System.Windows.Forms.ComboBox comboBox_KeySnapSwitch;
        private System.Windows.Forms.NumericUpDown numericUpDown_PixelSnap;
        private System.Windows.Forms.Label label_PixelSnap;
        private System.Windows.Forms.GroupBox groupBox_SnapOption;
    }
}