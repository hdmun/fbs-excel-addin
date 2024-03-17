namespace Excel.AddIn.View
{
    partial class SettingForm
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
            this.gbClassOutput = new System.Windows.Forms.GroupBox();
            this.listViewClassOutput = new System.Windows.Forms.ListView();
            this.colHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderEdit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClassOutputEdit = new System.Windows.Forms.Button();
            this.gbBinaryOutput = new System.Windows.Forms.GroupBox();
            this.listViewBinaryOutput = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBinaryOutputEdit = new System.Windows.Forms.Button();
            this.gbClassOutput.SuspendLayout();
            this.gbBinaryOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbClassOutput
            // 
            this.gbClassOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClassOutput.Controls.Add(this.listViewClassOutput);
            this.gbClassOutput.Controls.Add(this.btnClassOutputEdit);
            this.gbClassOutput.Location = new System.Drawing.Point(12, 13);
            this.gbClassOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbClassOutput.Name = "gbClassOutput";
            this.gbClassOutput.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbClassOutput.Size = new System.Drawing.Size(791, 170);
            this.gbClassOutput.TabIndex = 0;
            this.gbClassOutput.TabStop = false;
            this.gbClassOutput.Text = "클래스 파일 출력 위치";
            // 
            // listViewClassOutput
            // 
            this.listViewClassOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewClassOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderPath,
            this.colHeaderEdit});
            this.listViewClassOutput.HideSelection = false;
            this.listViewClassOutput.Location = new System.Drawing.Point(6, 58);
            this.listViewClassOutput.Name = "listViewClassOutput";
            this.listViewClassOutput.Size = new System.Drawing.Size(779, 105);
            this.listViewClassOutput.TabIndex = 2;
            this.listViewClassOutput.UseCompatibleStateImageBehavior = false;
            // 
            // btnClassOutputEdit
            // 
            this.btnClassOutputEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClassOutputEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassOutputEdit.Location = new System.Drawing.Point(710, 25);
            this.btnClassOutputEdit.Name = "btnClassOutputEdit";
            this.btnClassOutputEdit.Size = new System.Drawing.Size(75, 27);
            this.btnClassOutputEdit.TabIndex = 1;
            this.btnClassOutputEdit.Text = "수정";
            this.btnClassOutputEdit.UseVisualStyleBackColor = true;
            this.btnClassOutputEdit.Click += new System.EventHandler(this.btnClassOutputEdit_Click);
            // 
            // gbBinaryOutput
            // 
            this.gbBinaryOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBinaryOutput.Controls.Add(this.listViewBinaryOutput);
            this.gbBinaryOutput.Controls.Add(this.btnBinaryOutputEdit);
            this.gbBinaryOutput.Location = new System.Drawing.Point(18, 191);
            this.gbBinaryOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBinaryOutput.Name = "gbBinaryOutput";
            this.gbBinaryOutput.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBinaryOutput.Size = new System.Drawing.Size(791, 170);
            this.gbBinaryOutput.TabIndex = 3;
            this.gbBinaryOutput.TabStop = false;
            this.gbBinaryOutput.Text = "바이너리 파일 출력 위치";
            // 
            // listViewBinaryOutput
            // 
            this.listViewBinaryOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBinaryOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewBinaryOutput.HideSelection = false;
            this.listViewBinaryOutput.Location = new System.Drawing.Point(6, 58);
            this.listViewBinaryOutput.Name = "listViewBinaryOutput";
            this.listViewBinaryOutput.Size = new System.Drawing.Size(779, 105);
            this.listViewBinaryOutput.TabIndex = 2;
            this.listViewBinaryOutput.UseCompatibleStateImageBehavior = false;
            // 
            // btnBinaryOutputEdit
            // 
            this.btnBinaryOutputEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBinaryOutputEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBinaryOutputEdit.Location = new System.Drawing.Point(710, 25);
            this.btnBinaryOutputEdit.Name = "btnBinaryOutputEdit";
            this.btnBinaryOutputEdit.Size = new System.Drawing.Size(75, 27);
            this.btnBinaryOutputEdit.TabIndex = 1;
            this.btnBinaryOutputEdit.Text = "수정";
            this.btnBinaryOutputEdit.UseVisualStyleBackColor = true;
            this.btnBinaryOutputEdit.Click += new System.EventHandler(this.btnBinaryOutputEdit_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 377);
            this.Controls.Add(this.gbBinaryOutput);
            this.Controls.Add(this.gbClassOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingForm";
            this.Text = "Setting";
            this.gbClassOutput.ResumeLayout(false);
            this.gbBinaryOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbClassOutput;
        private System.Windows.Forms.Button btnClassOutputEdit;
        private System.Windows.Forms.ListView listViewClassOutput;
        private System.Windows.Forms.ColumnHeader colHeaderPath;
        private System.Windows.Forms.ColumnHeader colHeaderEdit;
        private System.Windows.Forms.GroupBox gbBinaryOutput;
        private System.Windows.Forms.ListView listViewBinaryOutput;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnBinaryOutputEdit;
    }
}