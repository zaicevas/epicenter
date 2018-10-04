using System;
using System.Windows.Forms;

namespace epicenterWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "All images|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var v in ofd.FileNames)
                {
                    BrowseListBox.Items.Add(v, false);
                }
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            for (var i=0; i<BrowseListBox.Items.Count; i++)
            {
                if (BrowseListBox.GetItemChecked(i))
                {
                    PlateRecognizer.processImageFile(BrowseListBox.Items[i].ToString());
                    MessageBox.Show(BrowseListBox.Items[i].ToString());
                }
            }
        }
    }
}
