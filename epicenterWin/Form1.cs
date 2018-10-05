using System;
using System.Collections.Generic;
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
            var fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All images|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff"
            };
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var v in fileDialog.FileNames)
                {
                    BrowseListBox.Items.Add(v, false);
                }
            }
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            var bMatched = false;
            var bChecked = false;
            for (var i=0; i<BrowseListBox.Items.Count; i++)
            {
                if (BrowseListBox.GetItemChecked(i))
                {
                    bChecked = true;
                    List<string> matched = PlateRecognizer.ProcessImageFile(BrowseListBox.Items[i].ToString());
                    bMatched = matched.Count != 0;
                    foreach (string s in matched)
                    {
                        MessageBox.Show(s);
                    }
                }
            }
            if (!bChecked)
            {
                MessageBox.Show("Please select at least one image!");
            }
            else if (!bMatched)
            {
                MessageBox.Show("Haven't found any plates!");
            }
        }
    }
}
