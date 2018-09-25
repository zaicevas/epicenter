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
        private String startText;  
        // TextBox searchTextBox;
        // Label historyLabel;
        public Form1()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
            this.ActiveControl = historyLabel;
            startText = searchTextBox.Text;
            mouseClick(null, null);

            fixScale();
            loadPhotos();
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
            pictureBox1.ImageLocation = "https://source.unsplash.com/random/134x134?sig=1";
            pictureBox1.Load();
            pictureBox2.ImageLocation = "https://source.unsplash.com/random/134x134?sig=2";
            pictureBox2.Load();
            pictureBox4.ImageLocation = "https://source.unsplash.com/random/134x134?sig=4";
            pictureBox4.Load();
            pictureBox5.ImageLocation = "https://source.unsplash.com/random/134x134?sig=5";
            pictureBox5.Load();
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

        private void searchTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            searchTextBox.Text = "";
            searchTextBox.ForeColor = SystemColors.WindowText;
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            searchTextBox.Text = startText;
            searchTextBox.ForeColor = SystemColors.GrayText;
        }
    }
}

/*
            searchTextBox1.ForeColor = SystemColors.GrayText;
 * 
 *             searchTextBox1.Text = "";
            searchTextBox1.ForeColor = SystemColors.WindowText;
 * 
 * */
