using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

namespace epicenterWin
{
    public partial class Form1 : Form
    {

        /* Face recognition */
        public VideoCapture Webcam { get; set; }
        public EigenFaceRecognizer FaceRecognition { get; set; }
        public CascadeClassifier FaceDetection { get; set; }
        public CascadeClassifier EyeDetection { get; set; }

        public Mat Frame { get; set; }

        public List<Image<Gray, byte>> Faces { get; set; }
        public List<int> IDs { get; set; }

        public int ProcessedImageWidth { get; set; } = 128;
        public int ProcessedImageHeight { get; set; } = 150;

        public int TimerCounter { get; set; } = 0;
        public int TimeLimit { get; set; } = 30;
        public int ScanCounter { get; set; } = 0;

        public string YMLPath { get; set; } = @"../../Algo/trainingData.yml";

        public Timer Timer { get; set; }

        public bool FaceSquare { get; set; } = false;
        public bool EyeSquare { get; set; } = false;

        // non-face recognition

        private MouseEventArgs _removeMe;

        public Form1()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;

            // face recognition
            FaceRecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);
            FaceDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Algo/haarcascade_frontalface_default.xml"));
            EyeDetection = new CascadeClassifier(System.IO.Path.GetFullPath(@"../../Algo/haarcascade_eye.xml"));
            Frame = new Mat();
            Faces = new List<Image<Gray, byte>>();
            IDs = new List<int>();
            BeginWebcam();
        }

        private void BeginWebcam()
        {
            if (Webcam == null)
                Webcam = new VideoCapture();

            Webcam.ImageGrabbed += Webcam_ImageGrabbed;
            Webcam.Start();
            OutputBox.AppendText($"Webcam Started...{Environment.NewLine}");
        }

        private void Webcam_ImageGrabbed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All images|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff"
            };
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var v in fileDialog.FileNames)
                {
                    if (!BrowseListBox.Items.Contains(v))
                        BrowseListBox.Items.Add(v, true);
                }
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            var bChecked = false;
            for (var i=0; i<BrowseListBox.Items.Count; i++)
            {
                if (BrowseListBox.GetItemChecked(i))
                {
                    bChecked = true;
                    List<string> matched = PlateRecognizer.ProcessImageFile(BrowseListBox.Items[i].ToString());
                    if (matched.Count == 0)
                    {
                        MessageBox.Show(BrowseListBox.Items[i].ToString() + '\n' + "Haven't found any plates!");
                        continue;
                    }
                    foreach (string s in matched)
                    {
                        MessageBox.Show(BrowseListBox.Items[i].ToString() + '\n' + s);
                    }
                }
            }
            if (!bChecked)
            {
                MessageBox.Show("Please select at least one image!");
            }
        }

        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void BrowseListBox_MouseDown(object sender, MouseEventArgs e)                               // catching right button (remove) click
        {
            if (e.Button != MouseButtons.Right)
                return;
            var index = BrowseListBox.IndexFromPoint(e.Location);
            removeContextMenu.Opening += (o, c) =>
            {
                if (index == CheckedListBox.NoMatches)
                    c.Cancel = true;
                else
                {
                    _removeMe = e;
                    c.Cancel = false;
                }
            };
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)                              // clicking remove
        {
            var index = BrowseListBox.IndexFromPoint(_removeMe.Location);
            BrowseListBox.Items.RemoveAt(index);
        }

        private void FilePathBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                var path = FilePathBox.Text;
                if (File.Exists(path) && !BrowseListBox.Items.Contains(path))
                {
                    BrowseListBox.Items.Add(path, true);
                    FilePathBox.Clear();
                }
                else
                {
                    MessageBox.Show("Wrong image path or it already in the list.");
                }
            }
        }
    }
}
