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
            this.btnClassOutputAdd = new System.Windows.Forms.Button();
            this.gbBinaryOutput = new System.Windows.Forms.GroupBox();
            this.btnBinaryOutputAdd = new System.Windows.Forms.Button();
            this.listBoxBinaryOutput = new System.Windows.Forms.ListBox();
            this.listBoxClassOutput = new System.Windows.Forms.ListBox();
            this.gbClassOutput.SuspendLayout();
            this.gbBinaryOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbClassOutput
            // 
            this.gbClassOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClassOutput.Controls.Add(this.listBoxClassOutput);
            this.gbClassOutput.Controls.Add(this.btnClassOutputAdd);
            this.gbClassOutput.Location = new System.Drawing.Point(12, 13);
            this.gbClassOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbClassOutput.Name = "gbClassOutput";
            this.gbClassOutput.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbClassOutput.Size = new System.Drawing.Size(791, 170);
            this.gbClassOutput.TabIndex = 0;
            this.gbClassOutput.TabStop = false;
            this.gbClassOutput.Text = "클래스 파일 출력 위치";
            // 
            // btnClassOutputAdd
            // 
            this.btnClassOutputAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClassOutputAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassOutputAdd.Location = new System.Drawing.Point(710, 25);
            this.btnClassOutputAdd.Name = "btnClassOutputAdd";
            this.btnClassOutputAdd.Size = new System.Drawing.Size(75, 27);
            this.btnClassOutputAdd.TabIndex = 1;
            this.btnClassOutputAdd.Text = "추가";
            this.btnClassOutputAdd.UseVisualStyleBackColor = true;
            this.btnClassOutputAdd.Click += new System.EventHandler(this.btnClassOutputAdd_Click);
            // 
            // gbBinaryOutput
            // 
            this.gbBinaryOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBinaryOutput.Controls.Add(this.listBoxBinaryOutput);
            this.gbBinaryOutput.Controls.Add(this.btnBinaryOutputAdd);
            this.gbBinaryOutput.Location = new System.Drawing.Point(18, 191);
            this.gbBinaryOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBinaryOutput.Name = "gbBinaryOutput";
            this.gbBinaryOutput.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBinaryOutput.Size = new System.Drawing.Size(791, 170);
            this.gbBinaryOutput.TabIndex = 3;
            this.gbBinaryOutput.TabStop = false;
            this.gbBinaryOutput.Text = "바이너리 파일 출력 위치";
            // 
            // btnBinaryOutputAdd
            // 
            this.btnBinaryOutputAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBinaryOutputAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBinaryOutputAdd.Location = new System.Drawing.Point(710, 25);
            this.btnBinaryOutputAdd.Name = "btnBinaryOutputAdd";
            this.btnBinaryOutputAdd.Size = new System.Drawing.Size(75, 27);
            this.btnBinaryOutputAdd.TabIndex = 1;
            this.btnBinaryOutputAdd.Text = "추가";
            this.btnBinaryOutputAdd.UseVisualStyleBackColor = true;
            this.btnBinaryOutputAdd.Click += new System.EventHandler(this.btnBinaryOutputAdd_Click);
            // 
            // listBoxBinaryOutput
            // 
            this.listBoxBinaryOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxBinaryOutput.FormattingEnabled = true;
            this.listBoxBinaryOutput.ItemHeight = 15;
            this.listBoxBinaryOutput.Location = new System.Drawing.Point(6, 60);
            this.listBoxBinaryOutput.Name = "listBoxBinaryOutput";
            this.listBoxBinaryOutput.Size = new System.Drawing.Size(773, 94);
            this.listBoxBinaryOutput.TabIndex = 3;
            this.listBoxBinaryOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxBinaryOutput_KeyDown);
            // 
            // listBoxClassOutput
            // 
            this.listBoxClassOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxClassOutput.FormattingEnabled = true;
            this.listBoxClassOutput.ItemHeight = 15;
            this.listBoxClassOutput.Location = new System.Drawing.Point(12, 58);
            this.listBoxClassOutput.Name = "listBoxClassOutput";
            this.listBoxClassOutput.Size = new System.Drawing.Size(773, 94);
            this.listBoxClassOutput.TabIndex = 4;
            this.listBoxClassOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxClassOutput_KeyDown);
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
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbClassOutput.ResumeLayout(false);
            this.gbBinaryOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbClassOutput;
        private System.Windows.Forms.Button btnClassOutputAdd;
        private System.Windows.Forms.GroupBox gbBinaryOutput;
        private System.Windows.Forms.Button btnBinaryOutputAdd;
        private System.Windows.Forms.ListBox listBoxBinaryOutput;
        private System.Windows.Forms.ListBox listBoxClassOutput;
    }
}