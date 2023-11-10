using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BitwiseAppwinform
{
   
    public partial class Form1 : Form
    {
        private Mat src1;
        private Mat src2;
        private Mat dst;


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            src1 = new Mat(250, 250, MatType.CV_8UC1, Scalar.All(0));
            src2 = new Mat(250, 250, MatType.CV_8UC1, Scalar.All(0));
        }

        private void btnBitwiseOR_Click(object sender, EventArgs e)
        {
           
            Mat image3 = new Mat(250,250,MatType.CV_8UC1,Scalar.All(0));

            OpenCvSharp.Point center = new OpenCvSharp.Point(image1.Width / 2, image1.Height / 2);

            Cv2.Circle(image1, center, 80, Scalar.All(255), -1);
            Cv2.Rectangle(image2, new OpenCvSharp.Point(0, 0), new OpenCvSharp.Point(125, 250), Scalar.All(255), -1);

            Cv2.BitwiseAnd(image1, image2, image3);

            bit = BitmapConverter.ToBitmap(image3);
            

        }
    }
}
