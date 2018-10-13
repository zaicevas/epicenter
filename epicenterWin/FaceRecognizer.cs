using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

using static Emgu.CV.Face.FaceRecognizer;

namespace epicenterWin
{
    public class FaceRecognizer
    {
        private const string _YMLPath = @"../../Algo/trainingData.yml";
        private const string _faceXML = @"../../Algo/haarcascade_frontalface_default.xml";
        private const string _eyeXML = @"../../Algo/haarcascade_eye.xml";

        private const int _threshold = 3750;
        private const int _imgHeight = 150;
        private const int _imgWidth = 128;

        private EigenFaceRecognizer _eigenFaceRecognizer;
        private CascadeClassifier _faceCascade;
        private CascadeClassifier _eyeCascade;

        private Timer _timer;
        private int _timeout = 50;
        private int _currentTick = 0;

        public Mat Frame { get; set; }
        public Image<Gray, byte> LastRecognized { get; private set; }

        private List<Image<Gray, byte>> _faces;
        private List<int> _ids;
        private int _currentTrainingId = -1;

        public bool DrawFaceSquare { get; set; }
        public bool DrawEyesSquare { get; set; }
        public VideoCapture VideoCapture { get; private set; }
        public PictureBox PictureBox { get; set; }

        public FaceRecognizer()
        {
            _eigenFaceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            _faceCascade = new CascadeClassifier(Path.GetFullPath(_faceXML));
            _eyeCascade = new CascadeClassifier(Path.GetFullPath(_eyeXML));
            Frame = new Mat();
            _faces = new List<Image<Gray, byte>>();
            _ids = new List<int>();
        }

        /// <summary>
        /// sets the _videoCapture object to a new videoCapture where
        /// the video is either the provided filename
        /// or if the filename is null then it opens up ze webcam
        /// </summary>
        /// <param name="filename"></param>
        public void CreateVideoCapture(string filename)
        {
            if (VideoCapture != null)
                return;

            if (filename == null)
                VideoCapture = new VideoCapture();
            else
                VideoCapture = new VideoCapture(filename);

            VideoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;
            VideoCapture.Start();
        }

        public Image<Gray, byte> GetFaceFromFrame(Mat frame)
        {
            if (frame == null)
                return null;
            Image<Gray, byte> grayScale = frame.ToImage<Gray, byte>();
            Rectangle[] arr = _faceCascade.DetectMultiScale(grayScale, 1.3, 5);
            if (arr.Length <= 0)
                return null;
            Image<Gray, byte> result = grayScale.Copy(arr[0]).Resize(_imgWidth, _imgHeight, Emgu.CV.CvEnum.Inter.Cubic);
            return result;
        }

        private void VideoCapture_ImageGrabbed(object sender, System.EventArgs e)
        {
            if (!VideoCapture.Retrieve(Frame))
                return;

            Image<Bgr, byte> image = Frame.ToImage<Bgr, byte>();
            Image<Gray, byte> grayFrame = image.Convert<Gray, byte>();
            Rectangle[] faces = _faceCascade.DetectMultiScale(grayFrame, 1.3, 5);
            Rectangle[] eyes = _eyeCascade.DetectMultiScale(grayFrame, 1.3, 5);

            if (DrawFaceSquare)
                foreach (Rectangle face in faces)
                    image.Draw(face, new Bgr(Color.BurlyWood), 3);
            if (DrawEyesSquare)
                foreach (Rectangle eye in eyes)
                    image.Draw(eye, new Bgr(Color.NavajoWhite), 3);

            if (PictureBox != null)
                PictureBox.Image = image.ToBitmap();
        }

        public void StartTraining(int id)
        {
            _currentTick = 0;
            _currentTrainingId = id;

            _timer = new Timer()
            {
                Interval = 300,
            };
            _timer.Tick += TrainingTick;
            _timer.Start();
        }

        private void TrainingTick(object sender, System.EventArgs e)
        {
            _currentTick++;
            RecognizeFrameAs(Frame, _currentTrainingId);
            if (_currentTick >= _timeout)
            {
                _timer.Stop();
                TrainAll();
            }
        }

        public void RecognizeFrameAs(Mat frame, int id)
        {
            if (frame == null)
                return;

            Image<Gray, byte> image = GetFaceFromFrame(frame);
            if (image == null)
                return;
            _faces.Add(image);
            _ids.Add(id);
        }

        public void TrainAll()
        {
            if (_faces.Count <= 0)
                return;
            _eigenFaceRecognizer.Train(_faces.ToArray(), _ids.ToArray());
            _eigenFaceRecognizer.Write(_YMLPath);
        }

        //TODO: return "Person" instead of id if matches missing
        //null if not.
        public int Recognize(Image<Gray, byte> grayImage)
        {
            int id = -1;
            if (grayImage == null)
                return -1;
            PredictionResult result = _eigenFaceRecognizer.Predict(grayImage);
            id = GetMatchingId(result, _threshold);
            return id;
        }

        public int GetMatchingId(PredictionResult result, int threshold)
        {
            string eigenLabel;
            float eigenDistance = -1;
            if (result.Label == -1)
            {
                eigenLabel = "Unknown";
                eigenDistance = 0;
            }
            else
            {
                eigenLabel = result.Label.ToString();
                eigenDistance = (float)result.Distance;
                eigenLabel = eigenDistance > threshold ? "Unknown" : result.Label.ToString();
            }
            return int.Parse(eigenLabel);
        }

        public string GetMatchingLabel(PredictionResult result, int threshold)
        {
            string eigenLabel;
            float eigenDistance = -1;
            if (result.Label == -1)
            {
                eigenLabel = "Unknown";
                eigenDistance = 0;
            }
            else
            {
                eigenLabel = result.Label.ToString();
                eigenDistance = (float)result.Distance;
                eigenLabel = eigenDistance > threshold ? "Unknown" : result.Label.ToString();
            }
            return eigenLabel + '\n' + "Distance: " + eigenDistance.ToString();
        }
    }
}
