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

namespace BlueTomato
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mat img = Cv2.ImRead("C:\\Temp\\img\\tomato.jpg");  
            Bitmap bitmap = img.ToBitmap();
            pictureBox1.Image = bitmap;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mat src = Cv2.ImRead("C:\\Temp\\img\\tomato.jpg");

            Mat hsv = new Mat(src.Size(),MatType.CV_8UC3);
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);
            Mat blue = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);

            Cv2.InRange(hsv, new Scalar(110, 100, 100), new Scalar(130, 255, 255), blue);
            Cv2.BitwiseAnd(hsv, hsv, dst, blue);
            Cv2.CvtColor(dst,dst,ColorConversionCodes.HSV2BGR   );

            Bitmap bitmap = dst.ToBitmap();

            pictureBox2.Image = bitmap;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
