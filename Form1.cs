﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace gmod_audio_converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ffmpegCheck.Checked = File.Exists(@"ffmpeg.exe");

            bool passedDependCheck = (File.Exists(@"ffmpeg.exe"));
            { if (!passedDependCheck) { MessageBox.Show("You are missing one or more dependencies. This application will not function without them.", "Error! Missing Dependencies", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); } }

            System.Windows.Forms.ToolTip btnToolTip = new System.Windows.Forms.ToolTip();
            btnToolTip.SetToolTip(this.button1, "Choose the folder where your audio files are stored.");

            List<string> sample_rate = new List<string>() { "44100", "22050", "11025" };
            comboBox1.DataSource = sample_rate;
            List<string> format = new List<string>() { ".wav", ".mp3" };
            comboBox2.DataSource = format;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog source = new FolderBrowserDialog();
            if (DialogResult.OK == source.ShowDialog())
            {
                string path = source.SelectedPath;
                System.Console.WriteLine(path);
                SourcePath.Text = path;
                SourcePath.Enabled = true;
                SourcePath.BackColor = Color.White;
            }
        }

        private void EncodeButt_Click(object sender, EventArgs e)
        {
            if ((SourcePath.Enabled))
            {
                progressBar.Maximum = 100;
                progressBar.Value = 0;

                int count = Directory.GetFiles(SourcePath.Text, "*.*").Length;
                int iteration = 0;
                string codec;

                Directory.CreateDirectory(SourcePath.Text + "\\encode\\");
                var out_path = SourcePath.Text + "\\encode\\";
                var source_path = SourcePath.Text;
                if (Equals(comboBox2.SelectedItem, ".wav")) {codec = "pcm_s16le";} else {codec = "libmp3lame";}
            
                if (Directory.Exists(SourcePath.Text))
                {
                    foreach (var file in Directory.GetFiles(SourcePath.Text, "*.*"))
                    {
                        Process process = new Process();    // Encode
                        process.StartInfo.FileName = "ffmpeg";
                        process.StartInfo.Arguments = "-y -i \u0022" + file + "\u0022 -c:a " + codec + " -ar " + comboBox1.SelectedItem + " \u0022" + out_path + Path.GetFileNameWithoutExtension(file) + comboBox2.SelectedItem + "\u0022";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                        iteration++;
                        progressBar.Value += 100 / count;
                        ErrorLbl.Text = "(" + iteration + " / " + count + ") Encoding " + Path.GetFileNameWithoutExtension(file);
                        process.WaitForExit();
                        File.Delete(file);
                        System.Console.WriteLine(process.StartInfo.Arguments);
                        if (iteration >= count)
                        {
                            ErrorLbl.Text = "Encoding complete. Converted " + iteration + " files to "+ comboBox2.SelectedItem + " at " + comboBox1.SelectedItem + " Hz";

                            if (Directory.Exists(out_path))
                            {
                                MoveDirectory(out_path, source_path);
                            }
                        }
                    }
                }
            }
            else
            {
                if (!SourcePath.Enabled)
                {
                    ErrorLbl.Text = "You did not select a source folder!";
                }

            }
        }

        public static void MoveDirectory(string source, string target)
        {
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }
            }
            Directory.Delete(source, true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
