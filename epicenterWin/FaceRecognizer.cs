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

        private Mat _frame;

        private List<Image<Gray, byte>> _faces;
        private List<int> _ids;

        public bool DrawFaceSquare { get; set; }
        public bool DrawEyesSquare { get; set; }
        public VideoCapture VideoCapture { get; private set; }
        public PictureBox PictureBox { get; set; }

        public FaceRecognizer()
        {
            _eigenFaceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            _faceCascade = new CascadeClassifier(Path.GetFullPath(_faceXML));
            _eyeCascade = new CascadeClassifier(Path.GetFullPath(_eyeXML));
            _frame = new Mat();
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

        private void VideoCapture_ImageGrabbed(object sender, System.EventArgs e)
        {
            if (!VideoCapture.Retrieve(_frame))
                return;

            Image<Bgr, byte> image = _frame.ToImage<Bgr, byte>();
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

        public void RecognizeFrameAs(Mat frame, int id)
        {
            if (frame == null)
                return;

            Image<Gray, byte> image = frame.ToImage<Gray, byte>();

            Rectangle[] detected = _faceCascade.DetectMultiScale(image, 1.3, 5);

            if (detected.Length > 0)
            {
                Image<Gray, byte> processedImage = image.Copy(detected[0]).Resize(_imgWidth, _imgHeight, Emgu.CV.CvEnum.Inter.Cubic);
                _faces.Add(processedImage);
                _ids.Add(id);
            }
        }

        public void TrainAll()
        {
            if (_faces.Count <= 0)
                return;
            _eigenFaceRecognizer.Train(_faces.ToArray(), _ids.ToArray());
            _eigenFaceRecognizer.Write(_YMLPath);
        }

        public void Recognize(Mat frame)
        {
            if (frame == null)
                return;
            Image<Gray, byte> grayImage = frame.ToImage<Gray, byte>();
            Rectangle[] detected = _faceCascade.DetectMultiScale(grayImage, 1.3, 5);
            if (detected.Length > 0)
            {
                Image<Gray, byte> processedImage = grayImage.Copy(detected[0]).Resize(_imgWidth, _imgHeight, Emgu.CV.CvEnum.Inter.Cubic);
                try
                {
                    PredictionResult result = _eigenFaceRecognizer.Predict(processedImage);
                }
                catch
                {

                }
            }
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
