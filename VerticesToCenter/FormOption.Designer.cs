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
            this.checkedListBox_EditablePolyLines = new System.Windows.Forms.CheckedListBox();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_SelectNone = new System.Windows.Forms.Button();
            this.tabControl_Option = new System.Windows.Forms.TabControl();
            this.tabPage_SelectLayers = new System.Windows.Forms.TabPage();
            this.button_SelectLayers_Confirm = new System.Windows.Forms.Button();
            this.tabPage_Setting = new System.Windows.Forms.TabPage();
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
            this.checkBox_CenterSnap = new System.Windows.Forms.CheckBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.tabControl_Option.SuspendLayout();
            this.tabPage_SelectLayers.SuspendLayout();
            this.tabPage_Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxFeaturesSelect)).BeginInit();
            this.groupBox_Pixel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RadiusChangeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox_EditablePolyLines
            // 
            this.checkedListBox_EditablePolyLines.CheckOnClick = true;
            this.checkedListBox_EditablePolyLines.FormattingEnabled = true;
            this.checkedListBox_EditablePolyLines.Location = new System.Drawing.Point(18, 6);
            this.checkedListBox_EditablePolyLines.Name = "checkedListBox_EditablePolyLines";
            this.checkedListBox_EditablePolyLines.Size = new System.Drawing.Size(181, 180);
            this.checkedListBox_EditablePolyLines.TabIndex = 1;
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.Location = new System.Drawing.Point(18, 212);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(73, 23);
            this.button_SelectAll.TabIndex = 2;
            this.button_SelectAll.Text = "SelectAll";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // button_SelectNone
            // 
            this.button_SelectNone.Location = new System.Drawing.Point(115, 214);
            this.button_SelectNone.Name = "button_SelectNone";
            this.button_SelectNone.Size = new System.Drawing.Size(84, 21);
            this.button_SelectNone.TabIndex = 3;
            this.button_SelectNone.Text = "SelectNone";
            this.button_SelectNone.UseVisualStyleBackColor = true;
            this.button_SelectNone.Click += new System.EventHandler(this.button_SelectNone_Click);
            // 
            // tabControl_Option
            // 
            this.tabControl_Option.Controls.Add(this.tabPage_SelectLayers);
            this.tabControl_Option.Controls.Add(this.tabPage_Setting);
            this.tabControl_Option.Location = new System.Drawing.Point(26, 12);
            this.tabControl_Option.Name = "tabControl_Option";
            this.tabControl_Option.SelectedIndex = 0;
            this.tabControl_Option.Size = new System.Drawing.Size(242, 306);
            this.tabControl_Option.TabIndex = 4;
            // 
            // tabPage_SelectLayers
            // 
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectLayers_Confirm);
            this.tabPage_SelectLayers.Controls.Add(this.checkedListBox_EditablePolyLines);
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectNone);
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectAll);
            this.tabPage_SelectLayers.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SelectLayers.Name = "tabPage_SelectLayers";
            this.tabPage_SelectLayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SelectLayers.Size = new System.Drawing.Size(234, 280);
            this.tabPage_SelectLayers.TabIndex = 0;
            this.tabPage_SelectLayers.Text = "SelectLayers";
            this.tabPage_SelectLayers.UseVisualStyleBackColor = true;
            // 
            // button_SelectLayers_Confirm
            // 
            this.button_SelectLayers_Confirm.Location = new System.Drawing.Point(18, 241);
            this.button_SelectLayers_Confirm.Name = "button_SelectLayers_Confirm";
            this.button_SelectLayers_Confirm.Size = new System.Drawing.Size(75, 23);
            this.button_SelectLayers_Confirm.TabIndex = 4;
            this.button_SelectLayers_Confirm.Text = "Confirm";
            this.button_SelectLayers_Confirm.UseVisualStyleBackColor = true;
            this.button_SelectLayers_Confirm.Click += new System.EventHandler(this.button_SelectLayers_Confirm_Click);
            // 
            // tabPage_Setting
            // 
            this.tabPage_Setting.Controls.Add(this.button_SettingDefault);
            this.tabPage_Setting.Controls.Add(this.button_Setting_Confirm);
            this.tabPage_Setting.Controls.Add(this.numericUpDown_MaxFeaturesSelect);
            this.tabPage_Setting.Controls.Add(this.label_MaxFeaturesSelect);
            this.tabPage_Setting.Controls.Add(this.groupBox_Pixel);
            this.tabPage_Setting.Controls.Add(this.label_SelectMode);
            this.tabPage_Setting.Controls.Add(this.comboBox_SelectMode);
            this.tabPage_Setting.Controls.Add(this.checkBox_CenterSnap);
            this.tabPage_Setting.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Setting.Name = "tabPage_Setting";
            this.tabPage_Setting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Setting.Size = new System.Drawing.Size(234, 280);
            this.tabPage_Setting.TabIndex = 1;
            this.tabPage_Setting.Text = "Setting";
            this.tabPage_Setting.UseVisualStyleBackColor = true;
            // 
            // button_SettingDefault
            // 
            this.button_SettingDefault.Location = new System.Drawing.Point(15, 223);
            this.button_SettingDefault.Name = "button_SettingDefault";
            this.button_SettingDefault.Size = new System.Drawing.Size(75, 28);
            this.button_SettingDefault.TabIndex = 6;
            this.button_SettingDefault.Text = "Default";
            this.button_SettingDefault.UseVisualStyleBackColor = true;
            this.button_SettingDefault.Click += new System.EventHandler(this.button_SettingDefault_Click);
            // 
            // button_Setting_Confirm
            // 
            this.button_Setting_Confirm.Location = new System.Drawing.Point(136, 223);
            this.button_Setting_Confirm.Name = "button_Setting_Confirm";
            this.button_Setting_Confirm.Size = new System.Drawing.Size(69, 28);
            this.button_Setting_Confirm.TabIndex = 6;
            this.button_Setting_Confirm.Text = "Confirm";
            this.button_Setting_Confirm.UseVisualStyleBackColor = true;
            this.button_Setting_Confirm.Click += new System.EventHandler(this.button_Setting_Confirm_Click);
            // 
            // numericUpDown_MaxFeaturesSelect
            // 
            this.numericUpDown_MaxFeaturesSelect.Location = new System.Drawing.Point(146, 168);
            this.numericUpDown_MaxFeaturesSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_MaxFeaturesSelect.Name = "numericUpDown_MaxFeaturesSelect";
            this.numericUpDown_MaxFeaturesSelect.Size = new System.Drawing.Size(51, 21);
            this.numericUpDown_MaxFeaturesSelect.TabIndex = 5;
            this.numericUpDown_MaxFeaturesSelect.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label_MaxFeaturesSelect
            // 
            this.label_MaxFeaturesSelect.AutoSize = true;
            this.label_MaxFeaturesSelect.Location = new System.Drawing.Point(23, 170);
            this.label_MaxFeaturesSelect.Name = "label_MaxFeaturesSelect";
            this.label_MaxFeaturesSelect.Size = new System.Drawing.Size(107, 12);
            this.label_MaxFeaturesSelect.TabIndex = 4;
            this.label_MaxFeaturesSelect.Text = "MaxFeaturesSelect";
            // 
            // groupBox_Pixel
            // 
            this.groupBox_Pixel.Controls.Add(this.numericUpDown_MaxRadius);
            this.groupBox_Pixel.Controls.Add(this.numericUpDown_RadiusChangeLimit);
            this.groupBox_Pixel.Controls.Add(this.label_MaxRadius);
            this.groupBox_Pixel.Controls.Add(this.label_RadiusChangeLimit);
            this.groupBox_Pixel.Location = new System.Drawing.Point(12, 64);
            this.groupBox_Pixel.Name = "groupBox_Pixel";
            this.groupBox_Pixel.Size = new System.Drawing.Size(193, 91);
            this.groupBox_Pixel.TabIndex = 3;
            this.groupBox_Pixel.TabStop = false;
            this.groupBox_Pixel.Text = "PixelOption";
            // 
            // numericUpDown_MaxRadius
            // 
            this.numericUpDown_MaxRadius.Location = new System.Drawing.Point(134, 53);
            this.numericUpDown_MaxRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_MaxRadius.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown_MaxRadius.Name = "numericUpDown_MaxRadius";
            this.numericUpDown_MaxRadius.Size = new System.Drawing.Size(53, 21);
            this.numericUpDown_MaxRadius.TabIndex = 3;
            this.numericUpDown_MaxRadius.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDown_RadiusChangeLimit
            // 
            this.numericUpDown_RadiusChangeLimit.Location = new System.Drawing.Point(134, 25);
            this.numericUpDown_RadiusChangeLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_RadiusChangeLimit.Name = "numericUpDown_RadiusChangeLimit";
            this.numericUpDown_RadiusChangeLimit.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown_RadiusChangeLimit.TabIndex = 2;
            this.numericUpDown_RadiusChangeLimit.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label_MaxRadius
            // 
            this.label_MaxRadius.AutoSize = true;
            this.label_MaxRadius.Location = new System.Drawing.Point(11, 53);
            this.label_MaxRadius.Name = "label_MaxRadius";
            this.label_MaxRadius.Size = new System.Drawing.Size(59, 12);
            this.label_MaxRadius.TabIndex = 1;
            this.label_MaxRadius.Text = "MaxRadius";
            // 
            // label_RadiusChangeLimit
            // 
            this.label_RadiusChangeLimit.AutoSize = true;
            this.label_RadiusChangeLimit.Location = new System.Drawing.Point(11, 27);
            this.label_RadiusChangeLimit.Name = "label_RadiusChangeLimit";
            this.label_RadiusChangeLimit.Size = new System.Drawing.Size(107, 12);
            this.label_RadiusChangeLimit.TabIndex = 0;
            this.label_RadiusChangeLimit.Text = "RadiusChangeLimit";
            // 
            // label_SelectMode
            // 
            this.label_SelectMode.AutoSize = true;
            this.label_SelectMode.Location = new System.Drawing.Point(7, 35);
            this.label_SelectMode.Name = "label_SelectMode";
            this.label_SelectMode.Size = new System.Drawing.Size(65, 12);
            this.label_SelectMode.TabIndex = 2;
            this.label_SelectMode.Text = "SelectMode";
            // 
            // comboBox_SelectMode
            // 
            this.comboBox_SelectMode.FormattingEnabled = true;
            this.comboBox_SelectMode.Location = new System.Drawing.Point(85, 28);
            this.comboBox_SelectMode.Name = "comboBox_SelectMode";
            this.comboBox_SelectMode.Size = new System.Drawing.Size(121, 20);
            this.comboBox_SelectMode.TabIndex = 1;
            // 
            // checkBox_CenterSnap
            // 
            this.checkBox_CenterSnap.AutoSize = true;
            this.checkBox_CenterSnap.Location = new System.Drawing.Point(6, 6);
            this.checkBox_CenterSnap.Name = "checkBox_CenterSnap";
            this.checkBox_CenterSnap.Size = new System.Drawing.Size(84, 16);
            this.checkBox_CenterSnap.TabIndex = 0;
            this.checkBox_CenterSnap.Text = "CenterSnap";
            this.checkBox_CenterSnap.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(26, 328);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // FormOptionVerticesToCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 363);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.tabControl_Option);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptionVerticesToCenter";
            this.Text = "OptionVerticesToCenter";
            this.tabControl_Option.ResumeLayout(false);
            this.tabPage_SelectLayers.ResumeLayout(false);
            this.tabPage_Setting.ResumeLayout(false);
            this.tabPage_Setting.PerformLayout();
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
    }
}