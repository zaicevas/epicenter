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
            bool b_matched = false;
            bool b_checked = false;
            for (var i=0; i<BrowseListBox.Items.Count; i++)
            {
                if (BrowseListBox.GetItemChecked(i))
                {
                    b_checked = true;
                    List<string> matched = PlateRecognizer.processImageFile(BrowseListBox.Items[i].ToString());
                    b_matched = matched.Count != 0 ? true : false;
                    foreach (string s in matched)
                    {
                        MessageBox.Show(s);
                    }
                }
            }
            if (!b_checked)
            {
                MessageBox.Show("Please select at least one image!");
            }
            else if (!b_matched)
            {
                MessageBox.Show("Haven't found any plates!");
            }
        }
    }
}
