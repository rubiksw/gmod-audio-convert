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
            bool ffmpegExists = File.Exists(@"ffmpeg.exe");
            Console.WriteLine();
            ffmpegCheck.Text = ffmpegExists ? "✔️ ffmpeg" : "❌ ffmpeg";
            
            if (!ffmpegExists) { MessageBox.Show("You are missing one or more dependencies. This application will not function without them.", "Error! Missing Dependencies", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            ToolTip btnToolTip = new ToolTip();
            btnToolTip.SetToolTip(btnfolderSelect, "Choose the folder where your audio files are stored.");

            List<string> sampleRate = new(){ "44100", "22050", "11025" };
            comboBox1.DataSource = sampleRate;
            List<string> format = new(){ ".wav", ".mp3" };
            comboBox2.DataSource = format;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog source = new FolderBrowserDialog();
            if (DialogResult.OK != source.ShowDialog()) return;

            SourcePath.Text = source.SelectedPath;
            SourcePath.Enabled = true;
            SourcePath.BackColor = Color.White;
        }

        private void EncodeButt_Click(object sender, EventArgs e)
        {
            if (!SourcePath.Enabled)
                ErrorLbl.Text = "You did not select a source folder!";
            
            progressBar.Maximum = 100;
            progressBar.Value = 0;

            var count = Directory.GetFiles(SourcePath.Text, "*.*").Length;
            var iteration = 0;

            Directory.CreateDirectory(Path.Combine(SourcePath.Text, @"\encode\"));
            var outPath = SourcePath.Text + "\\encode\\";
            var sourcePath = SourcePath.Text;
            var codec = Equals(comboBox2.SelectedItem, ".wav") ? "pcm_s16le" : "libmp3lame";
            if (!Directory.Exists(SourcePath.Text)) return;
            
            foreach (var file in Directory.GetFiles(SourcePath.Text, "*.*"))
            {
                Process process = new Process(); // Encode
                process.StartInfo.FileName = "ffmpeg";
                process.StartInfo.Arguments = "-y -i \u0022" + file + "\u0022 -c:a " + codec + " -ar " +
                                              comboBox1.SelectedItem + " \u0022" + outPath +
                                              Path.GetFileNameWithoutExtension(file) + comboBox2.SelectedItem +
                                              "\u0022";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                
                iteration++;
                progressBar.Value += 100 / count;
                ErrorLbl.Text = "(" + iteration + @" / " + count + ") Encoding " + Path.GetFileNameWithoutExtension(file);
                process.WaitForExit();
                
                File.Delete(file);
                Console.WriteLine(process.StartInfo.Arguments);
                
                if (iteration < count) continue;
                ErrorLbl.Text = "Encoding complete. Converted " + iteration + " files to " +
                                comboBox2.SelectedItem + " at " + comboBox1.SelectedItem + " Hz";

                if (!Directory.Exists(outPath)) return;

                MoveDirectory(outPath, sourcePath);
            }
        }

        private static void MoveDirectory(string source, string target)
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

    }
}
