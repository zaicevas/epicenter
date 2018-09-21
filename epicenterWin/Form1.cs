using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epicenterWin
{
    public partial class Form1 : Form
    {
       
        // TextBox searchTextBox;
        // Label historyLabel;
        public Form1()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
            this.ActiveControl = historyLabel;
           
            searchTextBox.ForeColor = SystemColors.GrayText;
            searchTextBox.Text = "Search people/car plate";

            fixScale();
            loadPhotos();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            searchTextBox.Text = "";
            searchTextBox.ForeColor = SystemColors.WindowText;
        }

        private void fixScale()
        {
            searchImg.SizeMode = PictureBoxSizeMode.Zoom;
            searchImg.BackColor = Color.Transparent;
            galleryImg.SizeMode = PictureBoxSizeMode.Zoom;
            galleryImg.BackColor = Color.Transparent;
        }

        private void loadPhotos()
        {
            pictureBox1.ImageLocation = "https://source.unsplash.com/random/100x89?sig=1";
            pictureBox1.Load();
            pictureBox2.ImageLocation = "https://source.unsplash.com/random/100x89?sig=2";
            pictureBox2.Load();
            pictureBox3.ImageLocation = "https://source.unsplash.com/random/100x89?sig=3";
            pictureBox3.Load();
            pictureBox4.ImageLocation = "https://source.unsplash.com/random/100x89?sig=4";
            pictureBox4.Load();
            pictureBox5.ImageLocation = "https://source.unsplash.com/random/100x89?sig=5";
            pictureBox5.Load();
            pictureBox6.ImageLocation = "https://source.unsplash.com/random/100x89?sig=6";
            pictureBox6.Load();
        }

        private void galleryClick(object sender, EventArgs e)
        {

        }

        private void galleryDragEnter(object sender, DragEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void galleryButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet");
        }
    }
}
