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
    public partial class MainForm : Form
    {
        // non-face recognition

        private MouseEventArgs _removeMe;

        private FaceRecognizer _faceRecognizer;


        public MainForm()
        {
            InitializeComponent();

            _faceRecognizer = new FaceRecognizer
            {
                PictureBox = webcamPictureBox,
                DrawEyesSquare = true,
                DrawFaceSquare = true
            };
            _faceRecognizer.CreateVideoCapture(null);

            Person Tomas = new Person()
            {
                FirstName = "TOMAS",
                LastName = "NOTTOMAS",
                Missing = true,
                FaceID = 5
            };
            SqliteDataAccess<Person>.CreateRow(Tomas);
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
            string txt = idTextBox.Text;
            if (txt == null | txt == string.Empty)
                return;
            int id = -1;
            int.TryParse(idTextBox.Text, out id);
            if (id == -1)
            {
                MessageBox.Show("Please enter a valid id!");
                return;
            }
            idTextBox.Enabled = !idTextBox.Enabled;
            trainingButton.Enabled = !trainingButton.Enabled;
            
            _faceRecognizer.StartTraining(id);

            idTextBox.Enabled = !idTextBox.Enabled;
            trainingButton.Enabled = !trainingButton.Enabled;
        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            Mat frame = _faceRecognizer.Frame;
            if (frame == null)
                return;

            Image<Gray, byte> img = _faceRecognizer.GetFaceFromFrame(frame);
            int prediction = _faceRecognizer.Recognize(img);
            MessageBox.Show(prediction.ToString());
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
                    MessageBox.Show("Wrong image path or it already in the list.");
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
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All images|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
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

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)                              // clicking remove
        {
            int index = BrowseListBox.IndexFromPoint(_removeMe.Location);
            BrowseListBox.Items.RemoveAt(index);
        }


    }
}
