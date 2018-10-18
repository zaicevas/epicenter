using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace epicenterWin
{
    class WebcamHandler
    {
        private const string _faceXML = @"../../Algo/haarcascade_frontalface_default.xml";
        private const string _eyeXML = @"../../Algo/haarcascade_eye.xml";

        private const int _imgHeight = 150;
        private const int _imgWidth = 128;

        public Mat Frame { get; set; }
        public bool IsCamAlive { get; set; }
        public VideoCapture VideoCapture { get; private set; }
        public bool DrawFaceSquare { get; set; }
        public bool DrawEyesSquare { get; set; }
        public PictureBox WebcamPictureBox { get; set; }

        private CascadeClassifier _faceCascade;
        private CascadeClassifier _eyeCascade;

        public WebcamHandler()
        {
            Frame = new Mat();
            _faceCascade = new CascadeClassifier(Path.GetFullPath(_faceXML));
            _eyeCascade = new CascadeClassifier(Path.GetFullPath(_eyeXML));
        }

        public void Start(PictureBox webcamPictureBox, string filename = null)
        {
            if (filename == null)
                VideoCapture = new VideoCapture();
            else
                VideoCapture = new VideoCapture(filename);

            WebcamPictureBox = webcamPictureBox;
            VideoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;
            VideoCapture.Start();
            IsCamAlive = true;
        }

        public void Stop()
        {
            VideoCapture.Dispose();
            IsCamAlive = false;
        }

        private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
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

            if (WebcamPictureBox != null)
                WebcamPictureBox.Image = image.ToBitmap();
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
    }
}
