using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

namespace epicenterWin
{
    public partial class MainForm : Form
    {

        private MouseEventArgs _removeMe;

        private FaceRecognizer _faceRecognizer;


        public MainForm()
        {
            InitializeComponent();

            _faceRecognizer = new FaceRecognizer(this)
            {
                PictureBox = webcamPictureBox,
                DrawEyesSquare = true,
                DrawFaceSquare = true,
            };
            _faceRecognizer.CreateVideoCapture(null);
        }

        private void TrainingButton_Click(object sender, EventArgs e)
        {
            string firstName = _firstNameTextBox.Text;
            string lastName = _lastNameTextBox.Text;
            if (firstName == null || firstName == string.Empty || lastName == null || lastName == string.Empty)
                return;

            _firstNameTextBox.Enabled = false;
            trainingButton.Enabled = false;
            recognizeButton.Enabled = false;
            _faceRecognizer.StartTraining(firstName, lastName);
        }

        public void TrainingStopped()
        {
            _firstNameTextBox.Enabled = true;
            trainingButton.Enabled = true;
            recognizeButton.Enabled = true;
        }

        private void RecognizeButton_Click(object sender, EventArgs e)
        {
            Mat frame = _faceRecognizer.Frame;
            if (frame == null)
                return;

            Image<Gray, byte> img = _faceRecognizer.GetFaceFromFrame(frame);
            Person prediction = _faceRecognizer.Recognize(img);

            if (prediction == null)
                MessageBox.Show("Unknown");
            else
                MessageBox.Show(prediction.FullName);
        }

        private void FilePathBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                string path = FilePathBox.Text;
                if (File.Exists(path) && !BrowseListBox.Items.Contains(path))
                {
                    BrowseListBox.Items.Add(path, true);
                    FilePathBox.Clear();
                }
                else
                {
                    MessageBox.Show("Wrong image path or it's already in the list.");
                }
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            bool bChecked = false;                                  
            for (int i = 0; i < BrowseListBox.Items.Count; i++)
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
            OpenBrowseDialog(BrowseListBox);
        }

        private void BrowseListBox_MouseDown(object sender, MouseEventArgs e)                               // catching right button (remove) click
        {
            if (e.Button != MouseButtons.Right)
                return;
            int index = BrowseListBox.IndexFromPoint(e.Location);
            removeContextMenu.Opening += (o, c) =>
            {
                if (index == ListBox.NoMatches)
                    c.Cancel = true;
                else
                {
                    _removeMe = e;
                    c.Cancel = false;
                }
            };
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)                              // clicking remove
        {
            CheckedListBox currentBox = Tabs.SelectedTab.Name == "_train" ? _trainCheckedListBox : BrowseListBox;
            int index = currentBox.IndexFromPoint(_removeMe.Location);
            currentBox.Items.RemoveAt(index);
        }

        private void _reportCarTab_Click(object sender, EventArgs e)
        {

        }

        private void _reportCarPlateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void _reportPersonReportButton_Click(object sender, EventArgs e)
        {
            string firstName = _reportPersonFirstNameTextBox.Text;
            string lastName = _reportPersonLastNameTextBox.Text;
            Regex nameRegex = new Regex(@"^[A-Z][a-z]*$");
            if (!nameRegex.IsMatch(firstName) || !nameRegex.IsMatch(lastName))
            {
                MessageBox.Show("Please make sure you write down First Name and Last Name correctly.");
                return;
            }
            Person newPerson = new Person(firstName, lastName);
            newPerson.Missing = _reportPersonMissingCheckBox.Checked ? 1 : 0;
            SqliteDataAccess<Person>.CreateRow(newPerson);
            MessageBox.Show("Created!");
        }

        private void _reportCarReportButton_Click(object sender, EventArgs e)
        {
            string carPlate = _reportCarPlateTextBox.Text;
            Regex ltuPlate = new Regex(@"^[A-z]{3}\d{3}$");

            if (!ltuPlate.IsMatch(carPlate))
            {
                MessageBox.Show("Please use Lithuanian number plate notation withuot -. E.g. \"EWQ153\"");
                return;
            }
            Plate newPlate = new Plate(carPlate);
            newPlate.Missing = _reportCarMissingCheckBox.Checked ? 1 : 0;
            newPlate.FirstName = _reportCarFirstNameTextBox.Text;
            newPlate.LastName = _reportCarLastNameTextBox.Text;
            SqliteDataAccess<Plate>.CreateRow(newPlate);
            MessageBox.Show("Created!");
        }

        private void _trainBrowseButton_Click(object sender, EventArgs e)
        {
            OpenBrowseDialog(_trainCheckedListBox);
        }

        private void OpenBrowseDialog(CheckedListBox browseListBox)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All images|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var v in fileDialog.FileNames)
                {
                    if (!browseListBox.Items.Contains(v))
                        browseListBox.Items.Add(v, true);
                }
            }
        }

        private void _trainCheckedListBox_MouseDown(object sender, MouseEventArgs e)
        {
            removeItem(e, _trainCheckedListBox);
        }

        private void removeItem(MouseEventArgs e, CheckedListBox browseListBox)
        {
            if (e.Button != MouseButtons.Right)
                return;
            int index = browseListBox.IndexFromPoint(e.Location);
            removeContextMenu.Opening += (o, c) =>
            {
                if (index == ListBox.NoMatches)
                    c.Cancel = true;
                else
                {
                    _removeMe = e;
                    c.Cancel = false;
                }
            };
        }

        private void _trainBrowserButton_Click(object sender, EventArgs e)
        {
        }

        private void _trainBrowseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                string path = _trainBrowseTextBox.Text;
                if (File.Exists(path) && !_trainCheckedListBox.Items.Contains(path))
                {
                    _trainCheckedListBox.Items.Add(path, true);
                    _trainBrowseTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Wrong image path or it's already in the list.");
                }
            }
        }

        public string[] GetTrainFileNames()
        {
            String[] paths = new string[_trainCheckedListBox.CheckedItems.Count];
            _trainCheckedListBox.CheckedItems.CopyTo(paths, 0);
            foreach (string path in paths)
            {
                System.Diagnostics.Debug.WriteLine(path);
            }
            return paths;
        }

    }
}