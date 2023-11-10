using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Windows.Forms;
using Tesseract;

namespace WindowsFormsApp633333
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
                    string loadedImagePath = openFileDialog.FileName;
                    ProcessImage(loadedImagePath);
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
                    // 코드 수정: 이미지 크롭을 통해 번호판 영역을 더 정확하게 추출
                    var plateRegion = new OpenCvSharp.Rect(boundingRect.X, boundingRect.Y, boundingRect.Width, boundingRect.Height);
                    Mat plateImage = new Mat(image, plateRegion);

                    using (var engine = new TesseractEngine(@"C:\\Temp\\tesseract\\tessdata", "eng", EngineMode.Default))
                    {
                        // 코드 수정: ToPix 대신 ToBitmap 사용
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

