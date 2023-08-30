
using gac.Properties;

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
            this.SelectFolderButt = new System.Windows.Forms.Button();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.EncodeButt = new System.Windows.Forms.Button();
            this.ErrorLbl = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SampleSelect = new System.Windows.Forms.ComboBox();
            this.QualityLbl = new System.Windows.Forms.Label();
            this.ffmpegCheck = new System.Windows.Forms.CheckBox();
            this.FormatLbl = new System.Windows.Forms.Label();
            this.FormalSelect = new System.Windows.Forms.ComboBox();
            this.shouldDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SelectFolderButt
            // 
            this.SelectFolderButt.Location = new System.Drawing.Point(13, 23);
            this.SelectFolderButt.Name = "SelectFolderButt";
            this.SelectFolderButt.Size = new System.Drawing.Size(120, 28);
            this.SelectFolderButt.TabIndex = 1;
            this.SelectFolderButt.Text = "Select Folder";
            this.SelectFolderButt.UseVisualStyleBackColor = true;
            this.SelectFolderButt.Click += new System.EventHandler(this.SelectFolderButt_Click);
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
            this.ErrorLbl.Location = new System.Drawing.Point(10, 147);
            this.ErrorLbl.MaximumSize = new System.Drawing.Size(380, 40);
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
            // SampleSelect
            // 
            this.SampleSelect.AllowDrop = true;
            this.SampleSelect.FormattingEnabled = true;
            this.SampleSelect.Location = new System.Drawing.Point(264, 65);
            this.SampleSelect.Name = "SampleSelect";
            this.SampleSelect.Size = new System.Drawing.Size(108, 21);
            this.SampleSelect.TabIndex = 10;
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
            this.ffmpegCheck.Location = new System.Drawing.Point(314, 181);
            this.ffmpegCheck.Name = "ffmpegCheck";
            this.ffmpegCheck.Size = new System.Drawing.Size(58, 17);
            this.ffmpegCheck.TabIndex = 8;
            this.ffmpegCheck.Text = "ffmpeg";
            this.ffmpegCheck.UseVisualStyleBackColor = true;
            // 
            // FormatLbl
            // 
            this.FormatLbl.AutoSize = true;
            this.FormatLbl.BackColor = System.Drawing.Color.Transparent;
            this.FormatLbl.Location = new System.Drawing.Point(25, 68);
            this.FormatLbl.Name = "FormatLbl";
            this.FormatLbl.Size = new System.Drawing.Size(42, 13);
            this.FormatLbl.TabIndex = 13;
            this.FormatLbl.Text = "Format:";
            // 
            // FormalSelect
            // 
            this.FormalSelect.AllowDrop = true;
            this.FormalSelect.FormattingEnabled = true;
            this.FormalSelect.Location = new System.Drawing.Point(73, 65);
            this.FormalSelect.Name = "FormalSelect";
            this.FormalSelect.Size = new System.Drawing.Size(108, 21);
            this.FormalSelect.TabIndex = 12;
            // 
            // shouldDelete
            // 
            this.shouldDelete.AutoSize = true;
            this.shouldDelete.Location = new System.Drawing.Point(12, 181);
            this.shouldDelete.Name = "shouldDelete";
            this.shouldDelete.Size = new System.Drawing.Size(113, 17);
            this.shouldDelete.TabIndex = 14;
            this.shouldDelete.Text = "Delete source files";
            this.shouldDelete.CheckedChanged += new System.EventHandler(this.shouldDelete_CheckedChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 198);
            this.Controls.Add(this.shouldDelete);
            this.Controls.Add(this.FormatLbl);
            this.Controls.Add(this.FormalSelect);
            this.Controls.Add(this.QualityLbl);
            this.Controls.Add(this.SampleSelect);
            this.Controls.Add(this.ffmpegCheck);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.EncodeButt);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.SelectFolderButt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Gmod Audio Encoder";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SelectFolderButt;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.Button EncodeButt;
        private System.Windows.Forms.Label ErrorLbl;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox SampleSelect;
        private System.Windows.Forms.Label QualityLbl;
        private System.Windows.Forms.CheckBox ffmpegCheck;
        private System.Windows.Forms.Label FormatLbl;
        private System.Windows.Forms.ComboBox FormalSelect;
        private System.Windows.Forms.CheckBox shouldDelete;
    }
}

