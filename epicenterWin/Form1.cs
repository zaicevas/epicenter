using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.Util;

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
        public int TimeLimit { get; set; } = 40;
        public int ScanCounter { get; set; } = 0;

        public string YMLPath { get; set; } = @"../../Algo/trainingData.yml";

        public Timer Timer { get; set; }

        public bool FaceSquare { get; set; } = true;
        public bool EyeSquare { get; set; } = true;

        private const int _threshold = 3750;               // value of FaceRecognizer.PredictionResult.distance to positively identify

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
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Bgr, byte>();

            if (imageFrame != null)
            {
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = FaceDetection.DetectMultiScale(grayFrame, 1.3, 5);
                var eyes = EyeDetection.DetectMultiScale(grayFrame, 1.3, 5);

                if (FaceSquare)
                {
                    foreach (var face in faces)
                    {
                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);
                    }
                }
                if (EyeSquare)
                {
                    foreach (var eye in eyes)
                    {
                        imageFrame.Draw(eye, new Bgr(Color.Yellow), 3);
                    }
                }
                webcamPictureBox.Image = imageFrame.ToBitmap();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void trainingButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != string.Empty)
            {
                OutputBox.AppendText($"Training has started. {Environment.NewLine}");
                idTextBox.Enabled = !idTextBox.Enabled;

                Timer = new Timer();
                Timer.Interval = 300;
                Timer.Tick += Timer_Tick;
                Timer.Start();
                trainingButton.Enabled = !trainingButton.Enabled;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            System.Diagnostics.Debug.WriteLine(TimerCounter);

            if (TimerCounter < TimeLimit)
            {
                TimerCounter++;

                if (imageFrame != null)
                {
                    var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);
                    //MessageBox.Show(faces.Count().ToString());
                    if (faces.Count() > 0)                      // linq
                    {
                        var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        Faces.Add(processedImage);
                        IDs.Add(Convert.ToInt32(idTextBox.Text));
                        ScanCounter++;
                        OutputBox.AppendText($"{ScanCounter} Successful Scans Taken...{Environment.NewLine}");
                        OutputBox.ScrollToCaret();
                    }
                }
            }
            else
            {
                if (Faces.Count > 0)                                                // should we use try catcth instead?
                {
                    System.Diagnostics.Debug.WriteLine("ADDED FACE IMAGES FOR TRAINING: " + Faces.ToArray().Length + '\n');
                    FaceRecognition.Train(Faces.ToArray(), IDs.ToArray());
                }
                EndTraining(Faces.Count > 0);
            }
        }

        private void EndTraining(bool facesDetected)
        {
            FaceRecognition.Write(YMLPath);
            Timer.Stop();
            TimerCounter = 0;
            trainingButton.Enabled = !trainingButton.Enabled;
            idTextBox.Enabled = !idTextBox.Enabled;
            OutputBox.AppendText($"Training Complete! {Environment.NewLine}");
            if (!facesDetected)
            {
                OutputBox.AppendText($"ERROR: No faces detected during training.{Environment.NewLine}");
                MessageBox.Show("Error: No faces detected during training.");
                return;
            }
            MessageBox.Show("Training complete!");
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

        private void CheckButton_Click(object sender, EventArgs e)
        {
            var bChecked = false;
            for (var i = 0; i < BrowseListBox.Items.Count; i++)
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

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            /*
            Image hardcodedFb = Image.FromFile(@"C:\Users\ferN\Downloads\29694782_1889732117744398_5234807235305013248_o.jpg");

            Bitmap bmpImage = (Bitmap)hardcodedFb;
            var imageFrame = new Image<Gray, byte>(bmpImage); */


            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, byte>();

            if (imageFrame != null)
            {
                var faces = FaceDetection.DetectMultiScale(imageFrame, 1.3, 5);
                MessageBox.Show($"Faces detected: {faces.Count()}");
                if (faces.Count() != 0)
                {
                    var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                    try
                    {
                        var result = FaceRecognition.Predict(processedImage);
                        MessageBox.Show(CheckRecognizeResults(result, _threshold));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No faces trained, can't recognize");
                    }

                }
                else
                {
                    MessageBox.Show("No faces found");
                }

            }
        }

        private string CheckRecognizeResults(FaceRecognizer.PredictionResult result, int threshold)          
        {
            // @param threshold should usually be in [0, 5000]
            string EigenLabel;
            float EigenDistance = -1;
            if (result.Label == -1)
            {
                EigenLabel = "Unknown";
                EigenDistance = 0;
            }
            else
            {
                EigenLabel = result.Label.ToString();
                EigenDistance = (float) result.Distance;
                EigenLabel = EigenDistance > threshold ? "Unknown" : result.Label.ToString();
            }
            return EigenLabel + '\n' + "Distance: " + EigenDistance.ToString();

        }


    }
}
