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
        private const string _faceXML = @"../../Algo/haarcascade_frontalface_default.xml";
        private const string _eyeXML = @"../../Algo/haarcascade_eye.xml";
        private const string _YMLPath = @"../../Algo/YMLFiles/";
        private const string _YMLFileName = @"person";
        private const string _YMLFileExtention = @".yml";

        private const int _threshold = 3750;
        private const int _imgHeight = 150;
        private const int _imgWidth = 128;

        private CascadeClassifier _faceCascade;
        private CascadeClassifier _eyeCascade;

        public bool IsCamAlive { get; set; }
        public bool NewPersonCreated { get; set; }
        private bool _ymlsRead = false;

        private Timer _timer;
        private int _timeout = 50;
        private int _currentTick = 0;

        private List<Person> _people;
        private WebcamHandler _webcamHandler;
        public WebcamHandler Webcam {
            get
            {
                return _webcamHandler;
            }
        }

        private Dictionary<string, EigenFaceRecognizer> _recognizers;
        private List<Image<Gray, byte>> _faces;
        private List<int> _ids;
        private Person _currentPerson;
        private int _currentTrainingID = -1;

        public Mat Frame;
        public bool DrawFaceSquare { get; set; }
        public bool DrawEyesSquare { get; set; }
        public PictureBox PictureBox { get; set; }
        private MainForm _mainForm;
        
        public FaceRecognizer()
        {
            Frame = new Mat();
            _faceCascade = new CascadeClassifier(Path.GetFullPath(_faceXML));
            _eyeCascade = new CascadeClassifier(Path.GetFullPath(_eyeXML));
            _faces = new List<Image<Gray, byte>>();
            _ids = new List<int>();
            _people = new List<Person>();
            _recognizers = new Dictionary<string, EigenFaceRecognizer>();
            _webcamHandler = new WebcamHandler()
            {
                DrawEyesSquare = true,
                DrawFaceSquare = true,
            };

            NewPersonCreated = true;
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
        /// should only be called when VideoCapture is disposed or null
        /// </summary>
        /// <param name="filename"></param>
        public void CreateVideoCapture(string filename = null)
        {
            _webcamHandler.Start(PictureBox);
            IsCamAlive = true;
        }

        public void StopVideoCapture()
        {
            _webcamHandler.Stop();
            IsCamAlive = false;
        }

        public void StartTraining(string firstName, string lastName)
        {
            _currentPerson = DataBaseConnector.FindPerson(firstName, lastName);
            if(_currentPerson == null)
            {
                _mainForm.TrainingStopped();
                MessageBox.Show("This person doesn't exist");
                return;
            }

            _currentTrainingID = _currentPerson.ID;
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
            Mat frame = _webcamHandler.Frame;
            Image<Gray, byte> image = _webcamHandler.GetFaceFromFrame(frame);
            if (image != null)
            {
                _faces.Add(image);
                _ids.Add(_currentTrainingID);
            }

            if (_currentTick >= _timeout)
            {
                _timer.Stop();
                _mainForm.TrainingStopped();
                TrainAll();
            }
        }

        public void TrainAll()
        {
            if (_faces.Count <= 0)
                return;

            DataBaseConnector.SaveNewFaces(_faces, _currentTrainingID);
            _faces.Clear();
            _ids.Clear();
            DataBaseConnector.LoadAllFaces(_faces, _ids, _currentTrainingID, _imgWidth, _imgHeight);
            string fullName = _currentPerson.FullName;
            EigenFaceRecognizer eigenFaceRecognizer;
            if (_recognizers.ContainsKey(fullName))
            {
                eigenFaceRecognizer = _recognizers[fullName];
                _recognizers.Remove(fullName);
            }
            else
                eigenFaceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);

            eigenFaceRecognizer.Train(_faces.ToArray(), _ids.ToArray());
            string YMLFullPath = _YMLPath + _YMLFileName + _currentTrainingID.ToString() + _YMLFileExtention;
            eigenFaceRecognizer.Write(YMLFullPath);
            if (_ymlsRead)
                _recognizers.Add(fullName, eigenFaceRecognizer);
            DataBaseConnector.UpdateYML(_currentPerson, YMLFullPath);
            _faces.Clear();
            _ids.Clear();
        }

        public Image<Gray, byte> GetFaceFromWebcam()
        {
            Mat frame = _webcamHandler.Frame;
            return _webcamHandler.GetFaceFromFrame(frame);
        }

        public Person Recognize(Image<Gray, byte> grayImage)
        {
            if (grayImage == null)
                return null;

            if (NewPersonCreated)
            {
                _people = DataBaseConnector.LoadAllPeople();
                NewPersonCreated = false;
            }

            if (!_ymlsRead)
            {
                foreach (Person person in _people.Where(p => p.YML != null)) {
                    EigenFaceRecognizer eigenFaceRecognizer = new EigenFaceRecognizer();
                    eigenFaceRecognizer.Read(person.YML);
                    _recognizers.Add(person.FullName, eigenFaceRecognizer);
                }
                _ymlsRead = true;
            }
            
            if (grayImage.Width != _imgWidth || grayImage.Height != _imgHeight)
            {
                grayImage = GetFaceFromImage(grayImage);
                if (grayImage == null)
                    return null;
            }

            PredictionResult closestResult = new PredictionResult
            {
                Distance = double.PositiveInfinity
            };
            foreach (EigenFaceRecognizer eigenFaceRecognizer in _recognizers.Values)
            {
                PredictionResult result = eigenFaceRecognizer.Predict(grayImage);
                if (result.Distance < closestResult.Distance)
                {
                    System.Diagnostics.Debug.WriteLine("PREVIOUS DISTANCE: " + closestResult.Distance);
                    System.Diagnostics.Debug.WriteLine("UPDATED DISTANCE: " + result.Distance);
                    closestResult = result;
                }
            }
            return GetMatchingPerson(closestResult, _threshold);
        }

        private Person GetMatchingPerson(PredictionResult result, int threshold)
        {
            if (result.Label == -1 || result.Distance > threshold)
                return null;

            try
            {
                System.Diagnostics.Debug.WriteLine(result.Distance);
                return _people.First(person => person.ID == result.Label);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return null;
        }

        private Image<Gray, byte> GetFaceFromImage(Image<Gray, byte> image)
        {
            Image<Gray, byte> grayImg = image.Convert<Gray, byte>();
            Rectangle[] faces = _faceCascade.DetectMultiScale(grayImg, 1.3, 5);
            if (image == null || faces.Length == 0)
                return null;
            return grayImg.Copy(faces[0]).Resize(_imgWidth, _imgHeight, Emgu.CV.CvEnum.Inter.Cubic);
        }

        public int TrainMultipleImages(string[] filePaths, Person target)
        {
            _currentPerson = DataBaseConnector.FindPerson(target.FirstName, target.LastName);
            _currentTrainingID = _currentPerson.ID;

            int faceCount = 0;                                       // number of faces sucessfully added to data set
            foreach (string filePath in filePaths)
            {
                string path = Path.GetFullPath(filePath);
                Image<Bgr, byte> img;
                try
                {
                    img = new Image<Bgr, byte>(path);
                }
                catch
                {
                    continue;
                }
                Image<Gray, byte> grayImg = img.Convert<Gray, byte>();
                Rectangle[] faces = _faceCascade.DetectMultiScale(grayImg, 1.3, 5);
                if (faces.Length == 1)
                {
                    Image<Gray, byte> faceSquare = grayImg.Copy(faces[0]).Resize(_imgWidth, _imgHeight, Emgu.CV.CvEnum.Inter.Cubic);
                    _faces.Add(faceSquare);
                    _ids.Add(_currentTrainingID);
                    faceCount++;
                }
            }

            TrainAll();
            return faceCount;
        }

        public static Image<Gray, byte> ConvertToGray(string imagePath)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(imagePath);
            Image<Gray, byte> grayImg = img.Convert<Gray, byte>();
            return grayImg;
        }

    }
}