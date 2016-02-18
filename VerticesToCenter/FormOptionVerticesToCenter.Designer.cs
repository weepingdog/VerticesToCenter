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
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox_EditablePolyLineNames = new System.Windows.Forms.CheckedListBox();
            this.button_SelectAll = new System.Windows.Forms.Button();
            this.button_SelectNone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "SelectLayers";
            // 
            // checkedListBox_EditablePolyLineNames
            // 
            this.checkedListBox_EditablePolyLineNames.FormattingEnabled = true;
            this.checkedListBox_EditablePolyLineNames.Location = new System.Drawing.Point(43, 45);
            this.checkedListBox_EditablePolyLineNames.Name = "checkedListBox_EditablePolyLineNames";
            this.checkedListBox_EditablePolyLineNames.Size = new System.Drawing.Size(181, 164);
            this.checkedListBox_EditablePolyLineNames.TabIndex = 1;
            // 
            // button_SelectAll
            // 
            this.button_SelectAll.Location = new System.Drawing.Point(44, 228);
            this.button_SelectAll.Name = "button_SelectAll";
            this.button_SelectAll.Size = new System.Drawing.Size(73, 23);
            this.button_SelectAll.TabIndex = 2;
            this.button_SelectAll.Text = "SelectAll";
            this.button_SelectAll.UseVisualStyleBackColor = true;
            this.button_SelectAll.Click += new System.EventHandler(this.button_SelectAll_Click);
            // 
            // button_SelectNone
            // 
            this.button_SelectNone.Location = new System.Drawing.Point(140, 229);
            this.button_SelectNone.Name = "button_SelectNone";
            this.button_SelectNone.Size = new System.Drawing.Size(84, 21);
            this.button_SelectNone.TabIndex = 3;
            this.button_SelectNone.Text = "SelectNone";
            this.button_SelectNone.UseVisualStyleBackColor = true;
            this.button_SelectNone.Click += new System.EventHandler(this.button_SelectNone_Click);
            // 
            // FormOptionVerticesToCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 267);
            this.Controls.Add(this.button_SelectNone);
            this.Controls.Add(this.button_SelectAll);
            this.Controls.Add(this.checkedListBox_EditablePolyLineNames);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(280, 400);
            this.Name = "FormOptionVerticesToCenter";
            this.Text = "FormOptionVerticesToCenter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox_EditablePolyLineNames;
        private System.Windows.Forms.Button button_SelectAll;
        private System.Windows.Forms.Button button_SelectNone;
    }
}