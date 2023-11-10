using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;
using Rect = OpenCvSharp.Rect;

namespace OpenCVPJ
{
    public partial class Form1 : Form
    {
        private Mat processedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(imagePath);
                    ProcessImage(imagePath);
                }
            }
        }

        private void ProcessImage(string imagePath)
        {
            Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);
            Mat gray = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.GaussianBlur(gray, gray, new OpenCvSharp.Size(5, 5), 0);
            Cv2.Threshold(gray, gray, 120, 255, ThresholdTypes.Binary);
            Cv2.Canny(gray, gray, 100, 200, 3);

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(gray, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, new OpenCvSharp.Point(0, 0));

            foreach (var contour in contours)
            {
                var rotatedRect = Cv2.MinAreaRect(contour);
                var boundingRect = rotatedRect.BoundingRect();

                double ratio = (double)boundingRect.Height / boundingRect.Width;

                if (ratio <= 2.5 && ratio >= 0.5 && Cv2.ContourArea(contour) <= 900 && Cv2.ContourArea(contour) >= 200)
                {
                    Cv2.DrawContours(image, new OpenCvSharp.Point[][] { contour }, 0, new Scalar(0, 255, 255), 1);
                    Cv2.Rectangle(image, boundingRect, new Scalar(255, 0, 0), 1);

                    // 조정된 부분: 이미지 크롭을 통해 번호판 영역을 더 정확하게 추출
                    var plateRegion = new Rect(boundingRect.X, boundingRect.Y, boundingRect.Width, boundingRect.Height);
                    Mat plateImage = new Mat(image, plateRegion);

                    using (var engine = new TesseractEngine(@"C:\\Temp\\tesseract\\tessdata", "eng", EngineMode.Default))
                    {
                        using (var page = engine.Process(plateImage.ToBitmap()))
                        {
                            var text = page.GetText();
                            this.Invoke((MethodInvoker)delegate
                            {
                                textBox1.Text = text;
                            });
                        }
                    }

                    processedImage = image;
                }
            }
        }
    }
}
