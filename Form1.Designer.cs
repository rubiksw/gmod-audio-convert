
namespace gmod_audio_converter
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.EncodeButt = new System.Windows.Forms.Button();
            this.ErrorLbl = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.QualityLbl = new System.Windows.Forms.Label();
            this.ffmpegCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SourcePath
            // 
            this.SourcePath.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SourcePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.SourcePath.Location = new System.Drawing.Point(138, 27);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(234, 20);
            this.SourcePath.TabIndex = 2;
            this.SourcePath.Text = "C:\\gmod\\sound\\weapons";
            // 
            // EncodeButt
            // 
            this.EncodeButt.Location = new System.Drawing.Point(252, 103);
            this.EncodeButt.Name = "EncodeButt";
            this.EncodeButt.Size = new System.Drawing.Size(120, 34);
            this.EncodeButt.TabIndex = 5;
            this.EncodeButt.Text = "Convert";
            this.EncodeButt.UseVisualStyleBackColor = true;
            this.EncodeButt.Click += new System.EventHandler(this.EncodeButt_Click);
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.BackColor = System.Drawing.SystemColors.Menu;
            this.ErrorLbl.Location = new System.Drawing.Point(12, 152);
            this.ErrorLbl.MaximumSize = new System.Drawing.Size(250, 40);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(0, 13);
            this.ErrorLbl.TabIndex = 6;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 103);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(231, 34);
            this.progressBar.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(264, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // QualityLbl
            // 
            this.QualityLbl.AutoSize = true;
            this.QualityLbl.BackColor = System.Drawing.Color.Transparent;
            this.QualityLbl.Location = new System.Drawing.Point(196, 68);
            this.QualityLbl.Name = "QualityLbl";
            this.QualityLbl.Size = new System.Drawing.Size(66, 13);
            this.QualityLbl.TabIndex = 11;
            this.QualityLbl.Text = "Sample rate:";
            // 
            // ffmpegCheck
            // 
            this.ffmpegCheck.AutoCheck = false;
            this.ffmpegCheck.AutoSize = true;
            this.ffmpegCheck.Location = new System.Drawing.Point(317, 169);
            this.ffmpegCheck.Name = "ffmpegCheck";
            this.ffmpegCheck.Size = new System.Drawing.Size(58, 17);
            this.ffmpegCheck.TabIndex = 8;
            this.ffmpegCheck.Text = "ffmpeg";
            this.ffmpegCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(25, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Format:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.AllowDrop = true;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(73, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(108, 21);
            this.comboBox2.TabIndex = 12;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 198);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.QualityLbl);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ffmpegCheck);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.EncodeButt);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Gmod Audio Encoder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.Button EncodeButt;
        private System.Windows.Forms.Label ErrorLbl;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label QualityLbl;
        private System.Windows.Forms.CheckBox ffmpegCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

