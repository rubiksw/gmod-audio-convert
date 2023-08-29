using System;
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
            this.AllowDrop = true;
            bool ffmpegExists = File.Exists(@"ffmpeg.exe");
            if (!ffmpegExists) { MessageBox.Show("You are missing one or more dependencies. This application will not function without them.", "Error! Missing Dependencies", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            ffmpegCheck.Checked = ffmpegExists;

            System.Windows.Forms.ToolTip btnToolTip = new System.Windows.Forms.ToolTip();
            btnToolTip.SetToolTip(this.SelectFolderButt, "Choose the folder where your audio files are stored.");

            List<string> sample_rate = new List<string>() { "44100", "22050", "11025" };
            SampleSelect.DataSource = sample_rate;
            List<string> format = new List<string>() { ".wav", ".mp3" };
            FormalSelect.DataSource = format;
        }

        private void SelectFolderButt_Click(object sender, EventArgs e)
        {
            OpenFileDialog source = new OpenFileDialog();
            source.ValidateNames = false;
            source.CheckFileExists = false;
            // Always default to Folder Selection.
            source.FileName = "Folder";
            if (DialogResult.OK == source.ShowDialog())
            {
                string path = Path.GetDirectoryName(source.FileName);
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
                if (Equals(FormalSelect.SelectedItem, ".wav")) { codec = "pcm_s16le"; } else { codec = "libmp3lame"; }

                if (Directory.Exists(SourcePath.Text))
                {
                    foreach (var file in Directory.GetFiles(SourcePath.Text, "*.*"))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "ffmpeg";
                        process.StartInfo.Arguments = "-y -i \u0022" + file + "\u0022 -c:a " + codec + " -ar " + SampleSelect.SelectedItem + " \u0022" + out_path + Path.GetFileNameWithoutExtension(file) + FormalSelect.SelectedItem + "\u0022";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                        iteration++;
                        progressBar.Value += 100 / count;
                        ErrorLbl.Text = "(" + iteration + " / " + count + ") Encoding " + Path.GetFileNameWithoutExtension(file);
                        process.WaitForExit();

                        if (shouldDelete.Checked)
                            File.Delete(file);

                        System.Console.WriteLine(process.StartInfo.Arguments);
                        if (iteration >= count)
                        {
                            ErrorLbl.Text = "Encoding complete. Converted " + iteration + " files to " + FormalSelect.SelectedItem + " at " + SampleSelect.SelectedItem + " Hz";
                            progressBar.Value = 0;

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
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories).GroupBy(s => Path.GetDirectoryName(s));

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

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            int count = files.Length;
            int iteration = 0;
            string codec;

            foreach (string file in files)
            {
                if (!file.EndsWith(".mp3") && !file.EndsWith(".wav")) continue;

                string path = Path.GetDirectoryName(file);
                Directory.CreateDirectory(path + "\\encode\\");

                var out_path = path + "\\encode\\";
                var source_path = path;
                if (Equals(FormalSelect.SelectedItem, ".wav")) { codec = "pcm_s16le"; } else { codec = "libmp3lame"; }

                Process process = new Process();
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = "-y -i \u0022" + file + "\u0022 -c:a " + codec + " -ar " + SampleSelect.SelectedItem + " \u0022" + out_path + Path.GetFileNameWithoutExtension(file) + FormalSelect.SelectedItem + "\u0022";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                iteration++;
                progressBar.Value += 100 / count;
                ErrorLbl.Text = "(" + iteration + " / " + count + ") Encoding " + Path.GetFileNameWithoutExtension(file);
                process.WaitForExit();
                
                if (shouldDelete.Checked)
                    File.Delete(file);

                System.Console.WriteLine(process.StartInfo.Arguments);
                if (iteration >= count)
                {
                    ErrorLbl.Text = "Encoding complete. Converted " + iteration + " files to " + FormalSelect.SelectedItem + " at " + SampleSelect.SelectedItem + " Hz";
                    progressBar.Value = 0;

                    if (Directory.Exists(out_path))
                    {
                        MoveDirectory(out_path, source_path);
                    }
                }
            };
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
