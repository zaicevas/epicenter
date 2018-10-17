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
        private const string _YMLPath = @"../../Algo/YMLFiles/";
        private const string _YMLFileName = @"person";
        private const string _YMLFileExtention = @".yml";
        private const string _faceXML = @"../../Algo/haarcascade_frontalface_default.xml";
        private const string _eyeXML = @"../../Algo/haarcascade_eye.xml";

        private const int _threshold = 3750;
        private const int _imgHeight = 150;
        private const int _imgWidth = 128;

        private CascadeClassifier _faceCascade;
        private CascadeClassifier _eyeCascade;

        private bool _ymlsRead = false;

        private Timer _timer;
        private int _timeout = 50;
        private int _currentTick = 0;

        public Mat Frame { get; set; }
        public Image<Gray, byte> LastRecognized { get; private set; }

        private List<Person> _people;
        private List<Face> _trainedFaces;

        private Dictionary<string, EigenFaceRecognizer> _recognizers;
        private List<Image<Gray, byte>> _faces;
        private List<int> _ids;
        private int _currentTrainingID = -1;
        private Person _currentPerson;

        public bool DrawFaceSquare { get; set; }
        public bool DrawEyesSquare { get; set; }
        public VideoCapture VideoCapture { get; private set; }
        public PictureBox PictureBox { get; set; }

        private MainForm _mainForm;

        public FaceRecognizer()
        {
            _faceCascade = new CascadeClassifier(Path.GetFullPath(_faceXML));
            _eyeCascade = new CascadeClassifier(Path.GetFullPath(_eyeXML));
            Frame = new Mat();
            _faces = new List<Image<Gray, byte>>();
            _ids = new List<int>();
            _people = new List<Person>();
            _trainedFaces = new List<Face>();
            _recognizers = new Dictionary<string, EigenFaceRecognizer>();

            Directory.CreateDirectory(_YMLPath);
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
        public void CreateVideoCapture(string filename = null)
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
        public Image<Gray, byte> GetFaceFromBmp(Bitmap img)
        {
            if (img == null)
                return null;
            Image<Gray, byte> grayScale = new Image<Gray, byte>(img);
            Rectangle[] arr = _faceCascade.DetectMultiScale(grayScale, 1.3, 5);
            if (arr.Length <= 0)
                return null;
            Image<Gray, byte> result = grayScale.Copy(arr[0]).Resize(_imgWidth, _imgHeight, Emgu.CV.CvEnum.Inter.Cubic);
            return result;
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

        public void StartTraining(string firstName, string lastName)
        {
            Person currentPerson = new Person(firstName, lastName);
            currentPerson = SqliteDataAccess<Person>.ReadByCompositeKey(currentPerson);

            if(_currentPerson == null)
            {
                _mainForm.TrainingStopped();
                MessageBox.Show("This person doesn't exist");
                return;
            }

            _currentTrainingID = _currentPerson.ID;
            _trainedFaces = SqliteDataAccess<Face>.ReadRows().ToList();
            
            foreach (Face face in _trainedFaces.Where(f => f.PersonID == _currentTrainingID)) {
                Image<Gray, byte> grayImage = new Image<Gray, byte>(_imgWidth, _imgHeight)
                {
                    Bytes = face.Blob
                };
                _faces.Add(grayImage);
                _ids.Add(_currentTrainingID);
            }

            _currentTick = 0;
            _timer = new Timer()
            {
                Interval = 300,
            };

            _timer.Tick += TrainingTick;
            _timer.Start();
        }

        private void TrainingTick(object sender, EventArgs e)
        {
            _currentTick++;
            RecognizeFrameAs(Frame, _currentTrainingID);
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

            Face face = new Face
            {
                Blob = image.Bytes,
                PersonID = _currentTrainingID
            };
            SqliteDataAccess<Face>.CreateRow(face);
            _faces.Add(image);
            _ids.Add(id);
        }

        public void TrainAll()
        {
            if (_faces.Count <= 0)
                return;

            EigenFaceRecognizer eigenFaceRecognizer;
            if (_recognizers.ContainsKey(_currentPerson.FullName))
            {
                eigenFaceRecognizer = _recognizers[_currentPerson.FullName];
                _recognizers.Remove(_currentPerson.FullName);
            }
            else
                eigenFaceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
            eigenFaceRecognizer.Train(_faces.ToArray(), _ids.ToArray());
            string YMLFullPath = _YMLPath + _YMLFileName + _currentTrainingID.ToString() + _YMLFileExtention;
            eigenFaceRecognizer.Write(YMLFullPath);
            if (_ymlsRead)
                _recognizers.Add(_currentPerson.FullName, eigenFaceRecognizer);
            _currentPerson.YML = YMLFullPath;
            SqliteDataAccess<Person>.UpdatePerson(_currentPerson);
            _faces.Clear();
            _ids.Clear();
        }

        public Person Recognize(Image<Gray, byte> grayImage)
        {
            if (grayImage == null)
                return null;

            if (_people.Count == 0)
                _people = SqliteDataAccess<Person>.ReadRows().ToList();

            if (!_ymlsRead)
            {
                foreach (Person person in _people.Where(p => p.YML != null)) {
                    EigenFaceRecognizer eigenFaceRecognizer = new EigenFaceRecognizer();
                    eigenFaceRecognizer.Read(person.YML);
                    _recognizers.Add(person.FullName, eigenFaceRecognizer);
                }
            }
            _ymlsRead = true;
            PredictionResult closestResult = new PredictionResult
            {
                Distance = double.PositiveInfinity
            };
            foreach (EigenFaceRecognizer eigenFaceRecognizer in _recognizers.Values)
            {
                PredictionResult result = eigenFaceRecognizer.Predict(grayImage);
                if (result.Distance < closestResult.Distance)
                    closestResult = result;
            }
            return GetMatchingPerson(closestResult, _threshold);
        }

        private Person GetMatchingPerson(PredictionResult result, int threshold)
        {
            if (result.Label == -1 || result.Distance > threshold)
            {
                return null;
            }
            try
            {
                return _people.First(person => person.ID == result.Label);
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