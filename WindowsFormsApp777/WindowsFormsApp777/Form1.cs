using System;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WindowsFormsApp777
{
    public partial class Form1 : Form
    {
        private CarLicensePlateRecognition recognition;

        public Form1()
        {
            InitializeComponent();
            recognition = new CarLicensePlateRecognition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    ProcessAndDisplayImage(selectedImagePath);
                }
            }
        }

        private void ProcessAndDisplayImage(string imagePath)
        {
            Mat image = new Mat(imagePath, ImreadModes.Color);
            Mat processedImage = recognition.ProcessImage(image);

            pictureBox1.Image = processedImage.ToBitmap();
        }
    }

    public class CarLicensePlateRecognition
    {
        public Mat ProcessImage(Mat inputImage)
        {
            Mat processedImage = new Mat();
            Cv2.CvtColor(inputImage, processedImage, ColorConversionCodes.BGR2GRAY);

            // 여기에 이미지 처리 로직 추가

            return processedImage;
        }
    }
}
