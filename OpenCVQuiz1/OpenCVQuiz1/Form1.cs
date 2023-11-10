using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVQuiz1
{
    public partial class Form1 : Form
    {
        Mat img = new Mat();

        Mat dst = new Mat();
        public Form1()
        {
            InitializeComponent();
            img = Cv2.ImRead("ㅎㄹ.jpg");

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Mat img = new Mat("ㅎㄹ.jpg");

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
