namespace VerticesToCenter
{
    partial class FormOptionVerticesToCenter
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
            this.checkedListBox_EditablePolyLineNames = new System.Windows.Forms.CheckedListBox();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_SelectNone = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_SelectLayers = new System.Windows.Forms.TabPage();
            this.tabPage_Setting = new System.Windows.Forms.TabPage();
            this.checkBox_SnapToCenter = new System.Windows.Forms.CheckBox();
            this.comboBox_SelectMode = new System.Windows.Forms.ComboBox();
            this.label_SelectMode = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage_SelectLayers.SuspendLayout();
            this.tabPage_Setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox_EditablePolyLineNames
            // 
            this.checkedListBox_EditablePolyLineNames.FormattingEnabled = true;
            this.checkedListBox_EditablePolyLineNames.Location = new System.Drawing.Point(18, 6);
            this.checkedListBox_EditablePolyLineNames.Name = "checkedListBox_EditablePolyLineNames";
            this.checkedListBox_EditablePolyLineNames.Size = new System.Drawing.Size(181, 228);
            this.checkedListBox_EditablePolyLineNames.TabIndex = 1;
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.Location = new System.Drawing.Point(18, 238);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(73, 23);
            this.button_SelectAll.TabIndex = 2;
            this.button_SelectAll.Text = "SelectAll";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // button_SelectNone
            // 
            this.button_SelectNone.Location = new System.Drawing.Point(115, 238);
            this.button_SelectNone.Name = "button_SelectNone";
            this.button_SelectNone.Size = new System.Drawing.Size(84, 21);
            this.button_SelectNone.TabIndex = 3;
            this.button_SelectNone.Text = "SelectNone";
            this.button_SelectNone.UseVisualStyleBackColor = true;
            this.button_SelectNone.Click += new System.EventHandler(this.button_SelectNone_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_SelectLayers);
            this.tabControl.Controls.Add(this.tabPage_Setting);
            this.tabControl.Location = new System.Drawing.Point(26, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(242, 314);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage_SelectLayers
            // 
            this.tabPage_SelectLayers.Controls.Add(this.checkedListBox_EditablePolyLineNames);
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectNone);
            this.tabPage_SelectLayers.Controls.Add(this.button_SelectAll);
            this.tabPage_SelectLayers.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SelectLayers.Name = "tabPage_SelectLayers";
            this.tabPage_SelectLayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SelectLayers.Size = new System.Drawing.Size(234, 288);
            this.tabPage_SelectLayers.TabIndex = 0;
            this.tabPage_SelectLayers.Text = "SelectLayers";
            this.tabPage_SelectLayers.UseVisualStyleBackColor = true;
            // 
            // tabPage_Setting
            // 
            this.tabPage_Setting.Controls.Add(this.label_SelectMode);
            this.tabPage_Setting.Controls.Add(this.comboBox_SelectMode);
            this.tabPage_Setting.Controls.Add(this.checkBox_SnapToCenter);
            this.tabPage_Setting.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Setting.Name = "tabPage_Setting";
            this.tabPage_Setting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Setting.Size = new System.Drawing.Size(234, 288);
            this.tabPage_Setting.TabIndex = 1;
            this.tabPage_Setting.Text = "Setting";
            this.tabPage_Setting.UseVisualStyleBackColor = true;
            // 
            // checkBox_SnapToCenter
            // 
            this.checkBox_SnapToCenter.AutoSize = true;
            this.checkBox_SnapToCenter.Location = new System.Drawing.Point(6, 6);
            this.checkBox_SnapToCenter.Name = "checkBox_SnapToCenter";
            this.checkBox_SnapToCenter.Size = new System.Drawing.Size(96, 16);
            this.checkBox_SnapToCenter.TabIndex = 0;
            this.checkBox_SnapToCenter.Text = "SnapToCenter";
            this.checkBox_SnapToCenter.UseVisualStyleBackColor = true;
            // 
            // comboBox_SelectMode
            // 
            this.comboBox_SelectMode.FormattingEnabled = true;
            this.comboBox_SelectMode.Location = new System.Drawing.Point(85, 28);
            this.comboBox_SelectMode.Name = "comboBox_SelectMode";
            this.comboBox_SelectMode.Size = new System.Drawing.Size(121, 20);
            this.comboBox_SelectMode.TabIndex = 1;
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
            // FormOptionVerticesToCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 363);
            this.Controls.Add(this.tabControl);
            this.Name = "FormOptionVerticesToCenter";
            this.Text = "FormOptionVerticesToCenter";
            this.tabControl.ResumeLayout(false);
            this.tabPage_SelectLayers.ResumeLayout(false);
            this.tabPage_Setting.ResumeLayout(false);
            this.tabPage_Setting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_EditablePolyLineNames;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.Button button_SelectNone;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_SelectLayers;
        private System.Windows.Forms.TabPage tabPage_Setting;
        private System.Windows.Forms.CheckBox checkBox_SnapToCenter;
        private System.Windows.Forms.Label label_SelectMode;
        private System.Windows.Forms.ComboBox comboBox_SelectMode;
    }
}