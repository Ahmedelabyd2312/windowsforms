using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image_slider
{
    public partial class Form1 : Form
    {
        private List<string> imagePaths;
        private int currentImageIndex = 0;
        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            imagePaths = new List<string>()
        {
            "C:\\Users\\Sky Hawk\\Desktop\\p1.jpg",
            "C:\\Users\\Sky Hawk\\Desktop\\p2.jpg",
            "C:\\Users\\Sky Hawk\\Desktop\\p3.jpg"
        };

            pictureBox1.ImageLocation = imagePaths[currentImageIndex];

            timer = new Timer();
            timer.Interval = 3000; // 3 seconds
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: Any initialization code for the form can go here
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowPreviousImage();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                imagePaths.Add(openFileDialog.FileName); // Add the selected image to the list
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowNextImage();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowNextImage();
        }

        private void ShowNextImage()
        {
            currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
            pictureBox1.ImageLocation = imagePaths[currentImageIndex];
        }

        private void ShowPreviousImage()
        {
            currentImageIndex = (currentImageIndex - 1 + imagePaths.Count) % imagePaths.Count;
            pictureBox1.ImageLocation = imagePaths[currentImageIndex];
        }
    }
}