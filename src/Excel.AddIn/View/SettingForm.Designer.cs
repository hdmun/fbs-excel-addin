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
            this.listBoxClassOutput = new System.Windows.Forms.ListBox();
            this.btnClassOutputAdd = new System.Windows.Forms.Button();
            this.gbBinaryOutput = new System.Windows.Forms.GroupBox();
            this.listBoxBinaryOutput = new System.Windows.Forms.ListBox();
            this.btnBinaryOutputAdd = new System.Windows.Forms.Button();
            this.gbFlatcOpt = new System.Windows.Forms.GroupBox();
            this.checkBoxFlatcRust = new System.Windows.Forms.CheckBox();
            this.checkBoxFlatcPy = new System.Windows.Forms.CheckBox();
            this.checkBoxFlatcGo = new System.Windows.Forms.CheckBox();
            this.checkBoxFlatcKotlin = new System.Windows.Forms.CheckBox();
            this.checkBoxFlatcJava = new System.Windows.Forms.CheckBox();
            this.checkBoxFlatcCpp = new System.Windows.Forms.CheckBox();
            this.checkBoxFlatcCsharp = new System.Windows.Forms.CheckBox();
            this.gbClassOutput.SuspendLayout();
            this.gbBinaryOutput.SuspendLayout();
            this.gbFlatcOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbClassOutput
            // 
            this.gbClassOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClassOutput.Controls.Add(this.listBoxClassOutput);
            this.gbClassOutput.Controls.Add(this.btnClassOutputAdd);
            this.gbClassOutput.Location = new System.Drawing.Point(12, 104);
            this.gbClassOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbClassOutput.Name = "gbClassOutput";
            this.gbClassOutput.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbClassOutput.Size = new System.Drawing.Size(791, 170);
            this.gbClassOutput.TabIndex = 0;
            this.gbClassOutput.TabStop = false;
            this.gbClassOutput.Text = "클래스 파일 출력 위치";
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
            this.gbBinaryOutput.Location = new System.Drawing.Point(12, 282);
            this.gbBinaryOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBinaryOutput.Name = "gbBinaryOutput";
            this.gbBinaryOutput.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBinaryOutput.Size = new System.Drawing.Size(791, 170);
            this.gbBinaryOutput.TabIndex = 3;
            this.gbBinaryOutput.TabStop = false;
            this.gbBinaryOutput.Text = "바이너리 파일 출력 위치";
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
            // btnBinaryOutputAdd
            // 
            this.btnBinaryOutputAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBinaryOutputAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBinaryOutputAdd.Location = new System.Drawing.Point(704, 25);
            this.btnBinaryOutputAdd.Name = "btnBinaryOutputAdd";
            this.btnBinaryOutputAdd.Size = new System.Drawing.Size(75, 27);
            this.btnBinaryOutputAdd.TabIndex = 1;
            this.btnBinaryOutputAdd.Text = "추가";
            this.btnBinaryOutputAdd.UseVisualStyleBackColor = true;
            this.btnBinaryOutputAdd.Click += new System.EventHandler(this.btnBinaryOutputAdd_Click);
            // 
            // gbFlatcOpt
            // 
            this.gbFlatcOpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFlatcOpt.Controls.Add(this.checkBoxFlatcRust);
            this.gbFlatcOpt.Controls.Add(this.checkBoxFlatcPy);
            this.gbFlatcOpt.Controls.Add(this.checkBoxFlatcGo);
            this.gbFlatcOpt.Controls.Add(this.checkBoxFlatcKotlin);
            this.gbFlatcOpt.Controls.Add(this.checkBoxFlatcJava);
            this.gbFlatcOpt.Controls.Add(this.checkBoxFlatcCpp);
            this.gbFlatcOpt.Controls.Add(this.checkBoxFlatcCsharp);
            this.gbFlatcOpt.Location = new System.Drawing.Point(12, 13);
            this.gbFlatcOpt.Name = "gbFlatcOpt";
            this.gbFlatcOpt.Size = new System.Drawing.Size(786, 84);
            this.gbFlatcOpt.TabIndex = 4;
            this.gbFlatcOpt.TabStop = false;
            this.gbFlatcOpt.Text = "flatc 컴파일 언어";
            // 
            // checkBoxFlatcRust
            // 
            this.checkBoxFlatcRust.AutoSize = true;
            this.checkBoxFlatcRust.Location = new System.Drawing.Point(398, 24);
            this.checkBoxFlatcRust.Name = "checkBoxFlatcRust";
            this.checkBoxFlatcRust.Size = new System.Drawing.Size(59, 19);
            this.checkBoxFlatcRust.TabIndex = 6;
            this.checkBoxFlatcRust.Text = "Rust";
            this.checkBoxFlatcRust.UseVisualStyleBackColor = true;
            this.checkBoxFlatcRust.CheckedChanged += new System.EventHandler(this.checkBoxFlatc_CheckedChanged);
            // 
            // checkBoxFlatcPy
            // 
            this.checkBoxFlatcPy.AutoSize = true;
            this.checkBoxFlatcPy.Location = new System.Drawing.Point(316, 24);
            this.checkBoxFlatcPy.Name = "checkBoxFlatcPy";
            this.checkBoxFlatcPy.Size = new System.Drawing.Size(76, 19);
            this.checkBoxFlatcPy.TabIndex = 5;
            this.checkBoxFlatcPy.Text = "Python";
            this.checkBoxFlatcPy.UseVisualStyleBackColor = true;
            this.checkBoxFlatcPy.CheckedChanged += new System.EventHandler(this.checkBoxFlatc_CheckedChanged);
            // 
            // checkBoxFlatcGo
            // 
            this.checkBoxFlatcGo.AutoSize = true;
            this.checkBoxFlatcGo.Location = new System.Drawing.Point(261, 24);
            this.checkBoxFlatcGo.Name = "checkBoxFlatcGo";
            this.checkBoxFlatcGo.Size = new System.Drawing.Size(49, 19);
            this.checkBoxFlatcGo.TabIndex = 4;
            this.checkBoxFlatcGo.Text = "Go";
            this.checkBoxFlatcGo.UseVisualStyleBackColor = true;
            this.checkBoxFlatcGo.CheckedChanged += new System.EventHandler(this.checkBoxFlatc_CheckedChanged);
            // 
            // checkBoxFlatcKotlin
            // 
            this.checkBoxFlatcKotlin.AutoSize = true;
            this.checkBoxFlatcKotlin.Location = new System.Drawing.Point(191, 24);
            this.checkBoxFlatcKotlin.Name = "checkBoxFlatcKotlin";
            this.checkBoxFlatcKotlin.Size = new System.Drawing.Size(64, 19);
            this.checkBoxFlatcKotlin.TabIndex = 3;
            this.checkBoxFlatcKotlin.Text = "Kotlin";
            this.checkBoxFlatcKotlin.UseVisualStyleBackColor = true;
            this.checkBoxFlatcKotlin.CheckedChanged += new System.EventHandler(this.checkBoxFlatc_CheckedChanged);
            // 
            // checkBoxFlatcJava
            // 
            this.checkBoxFlatcJava.AutoSize = true;
            this.checkBoxFlatcJava.Location = new System.Drawing.Point(126, 24);
            this.checkBoxFlatcJava.Name = "checkBoxFlatcJava";
            this.checkBoxFlatcJava.Size = new System.Drawing.Size(59, 19);
            this.checkBoxFlatcJava.TabIndex = 2;
            this.checkBoxFlatcJava.Text = "Java";
            this.checkBoxFlatcJava.UseVisualStyleBackColor = true;
            this.checkBoxFlatcJava.CheckedChanged += new System.EventHandler(this.checkBoxFlatc_CheckedChanged);
            // 
            // checkBoxFlatcCpp
            // 
            this.checkBoxFlatcCpp.AutoSize = true;
            this.checkBoxFlatcCpp.Location = new System.Drawing.Point(65, 24);
            this.checkBoxFlatcCpp.Name = "checkBoxFlatcCpp";
            this.checkBoxFlatcCpp.Size = new System.Drawing.Size(55, 19);
            this.checkBoxFlatcCpp.TabIndex = 1;
            this.checkBoxFlatcCpp.Text = "C++";
            this.checkBoxFlatcCpp.UseVisualStyleBackColor = true;
            this.checkBoxFlatcCpp.CheckedChanged += new System.EventHandler(this.checkBoxFlatc_CheckedChanged);
            // 
            // checkBoxFlatcCsharp
            // 
            this.checkBoxFlatcCsharp.AutoSize = true;
            this.checkBoxFlatcCsharp.Location = new System.Drawing.Point(12, 24);
            this.checkBoxFlatcCsharp.Name = "checkBoxFlatcCsharp";
            this.checkBoxFlatcCsharp.Size = new System.Drawing.Size(47, 19);
            this.checkBoxFlatcCsharp.TabIndex = 0;
            this.checkBoxFlatcCsharp.Text = "C#";
            this.checkBoxFlatcCsharp.UseVisualStyleBackColor = true;
            this.checkBoxFlatcCsharp.CheckedChanged += new System.EventHandler(this.checkBoxFlatc_CheckedChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 473);
            this.Controls.Add(this.gbFlatcOpt);
            this.Controls.Add(this.gbBinaryOutput);
            this.Controls.Add(this.gbClassOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingForm";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.gbClassOutput.ResumeLayout(false);
            this.gbBinaryOutput.ResumeLayout(false);
            this.gbFlatcOpt.ResumeLayout(false);
            this.gbFlatcOpt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbClassOutput;
        private System.Windows.Forms.Button btnClassOutputAdd;
        private System.Windows.Forms.GroupBox gbBinaryOutput;
        private System.Windows.Forms.Button btnBinaryOutputAdd;
        private System.Windows.Forms.ListBox listBoxBinaryOutput;
        private System.Windows.Forms.ListBox listBoxClassOutput;
        private System.Windows.Forms.GroupBox gbFlatcOpt;
        private System.Windows.Forms.CheckBox checkBoxFlatcCpp;
        private System.Windows.Forms.CheckBox checkBoxFlatcCsharp;
        private System.Windows.Forms.CheckBox checkBoxFlatcPy;
        private System.Windows.Forms.CheckBox checkBoxFlatcGo;
        private System.Windows.Forms.CheckBox checkBoxFlatcKotlin;
        private System.Windows.Forms.CheckBox checkBoxFlatcJava;
        private System.Windows.Forms.CheckBox checkBoxFlatcRust;
    }
}