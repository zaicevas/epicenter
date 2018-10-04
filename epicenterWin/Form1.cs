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

        private void _searchUploadButton_Click(object sender, EventArgs e)
        {
            PlateRecognizer PR = new PlateRecognizer();
            PR.processImageFile(@"C:\Users\ferN\plate_testing\bmw.jpg");
        }
    }
}
