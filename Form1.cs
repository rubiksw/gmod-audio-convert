using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

            List<string> items = new List<string>() { "44100", "22050", "11025" };
            comboBox1.DataSource = items;
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

                if (Directory.Exists(SourcePath.Text))
                {
                    foreach (var file in Directory.GetFiles(SourcePath.Text, "*.*"))
                    {
                        Process process = new Process();    // Encode
                        process.StartInfo.FileName = "ffmpeg";
                        process.StartInfo.Arguments = "-y -i \u0022" + file + "\u0022 -c:a libmp3lame -ar " + comboBox1.SelectedItem + " \u0022" + SourcePath.Text + "\\" + Path.GetFileNameWithoutExtension(file) + ".mp3\u0022";
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
                            ErrorLbl.Text = "Encoding complete. Converted " + iteration + " files to MP3 at " + SourcePath.Text + "Hz";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
