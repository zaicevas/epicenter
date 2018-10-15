using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private bool initialized = false;

        private Timer _timer;
        private int _timeout = 50;
        private int _currentTick = 0;

        public Mat Frame { get; set; }
        public Image<Gray, byte> LastRecognized { get; private set; }

        private List<Image<Gray, byte>> _facesToSave;
        private List<int> _idsToSave;

        private List<Image<Gray, byte>> _faces;
        private List<int> _ids;
        private int _currentTrainingId = -1;

        public bool DrawFaceSquare { get; set; }
        public bool DrawEyesSquare { get; set; }
        public VideoCapture VideoCapture { get; private set; }
        public PictureBox PictureBox { get; set; }

        private MainForm _mainForm;

        public FaceRecognizer()
        {
            _eigenFaceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            _faceCascade = new CascadeClassifier(Path.GetFullPath(_faceXML));
            _eyeCascade = new CascadeClassifier(Path.GetFullPath(_eyeXML));
            Frame = new Mat();
            _faces = new List<Image<Gray, byte>>();
            _ids = new List<int>();

            _facesToSave = new List<Image<Gray, byte>>();
            _idsToSave = new List<int>();

            PrepareForRecognizing();
        }

        public FaceRecognizer(MainForm mainForm) : this()
        {
            _mainForm = mainForm;
        }
        /// <summary>
        /// sets the _videoCapture object to a new videoCapture where
        /// the video is either the provided filename
        /// or if the filename is null then it opens up ze webcam
        /// </summary>
        /// <param name="filename"></param>
        private void PrepareForRecognizing()
        {
            try
            {
                if (SqliteDataAccess<Face>.ReadRows() != null)
                {
                    List<Face> trainedFaces = SqliteDataAccess<Face>.ReadRows().ToList();
                    foreach (Face face in trainedFaces)
                    {
                        Image<Gray, byte> grayImage = new Image<Gray, byte>(_imgWidth, _imgHeight)
                        {
                            Bytes = face.Blob
                        };
                        _faces.Add(grayImage);
                        _ids.Add(face.PersonID);
                    }
                    TrainAll();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            initialized = true;
        }

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
                _mainForm.TrainingStopped();
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
            _facesToSave.Add(image);
            _idsToSave.Add(id);
        }

        public void TrainAll()
        {
            if (_facesToSave.Count <= 0)
                return;

            if (initialized)
            {
                foreach (Image<Gray, byte> image in _facesToSave)
                {
                    Face face = new Face
                    {
                        Blob = image.Bytes,
                        PersonID = _idsToSave[0]                                                    //all labels are the same
                    };
                    SqliteDataAccess<Face>.CreateRow(face);
                    _faces.Add(image);
                    _ids.Add(_idsToSave[0]);
                }
            }

            _eigenFaceRecognizer.Train(_faces.ToArray(), _ids.ToArray());
            _eigenFaceRecognizer.Write(_YMLPath);

            _facesToSave.Clear();                                                                   //clearing lists so we don't save same images again in DB
            _idsToSave.Clear();
        }

        //TODO: return "Person" instead of id if matches missing
        //null if not.
        public Person Recognize(Image<Gray, byte> grayImage)
        {
            if (grayImage == null)
                return null;
            PredictionResult result = _eigenFaceRecognizer.Predict(grayImage);
            return GetMatchingPerson(result, _threshold);
        }

        private Person GetMatchingPerson(PredictionResult result, int threshold)
        {
            if (result.Label == -1 || result.Distance > threshold)
            {
                return null;
            }

            try
            {
                List<Person> people = SqliteDataAccess<Person>.ReadRows().ToList();
                foreach (Person person in people)
                {
                    if (person.ID == result.Label)
                    {
                        return person;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return null;
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