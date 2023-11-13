using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCVPJ
{
    public partial class Form1 : Form
    {
        private Mat image;

        public Form1()
        {
            InitializeComponent();
        }

        private Mat Preprocessing(Mat image)
        {
            Mat gray = new Mat();
            Mat thImg = new Mat();
            Mat morph = new Mat();
            OpenCvSharp.Size kernelSize = new OpenCvSharp.Size(15, 5);
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, kernelSize);

            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Blur(gray, gray, new OpenCvSharp.Size(5, 5));
            Cv2.Sobel(gray, gray, MatType.CV_8U, 1, 0, 3);

            Cv2.Threshold(gray, thImg, 120, 255, ThresholdTypes.Binary);
            Cv2.MorphologyEx(thImg, morph, MorphTypes.Close, kernel, iterations: 2);

            Cv2.ImShow("th_img", thImg);
            Cv2.ImShow("morph", morph);

            return morph;
        }

        private bool VerifyPlate(RotatedRect mr)
        {
            Size2f size = mr.Size;
            float aspect = size.Height / size.Width;

            if (aspect < 1)
                aspect = 1 / aspect;

            bool ch1 = (size.Width * size.Height) > 2000 && (size.Width * size.Height) < 30000;

            bool ch2 = aspect > 1.0 && aspect < 6.4;

            return ch1 && ch2;
        }

        private void FindCandidates(Mat img, List<RotatedRect> candidates)
        {
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(img.Clone(), out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            foreach (var contour in contours)
            {
                RotatedRect rotRect = Cv2.MinAreaRect(contour);
                if (VerifyPlate(rotRect))
                    candidates.Add(rotRect);
            }
        }

        private void DrawRotatedRect(Mat img, RotatedRect mr, Scalar color, int thickness = 2)
        {
            Point2f[] pts = mr.Points();

            for (int i = 0; i < 4; i++)
            {
                PointF pt1 = new PointF(pts[i].X, pts[i].Y);
                PointF pt2 = new PointF(pts[(i + 1) % 4].X, pts[(i + 1) % 4].Y);

                OpenCvSharp.Point roundedPt1 = new OpenCvSharp.Point((int)Math.Round(pt1.X), (int)Math.Round(pt1.Y));
                OpenCvSharp.Point roundedPt2 = new OpenCvSharp.Point((int)Math.Round(pt2.X), (int)Math.Round(pt2.Y));

                Cv2.Line(img, roundedPt1, roundedPt2, color, thickness);
            }
        }
        public List<Mat> MakeCandidates(Mat image, List<RotatedRect> candidates)
        {
            List<Mat> candidatesImg = new List<Mat>();

            for (int i = 0; i < candidates.Count; i++)
            {
                RefineCandidate(image, candidates[i], candidates);

                if (VerifyPlate(candidates[i])) // Assuming VerifyPlate is a method that returns a bool
                {
                    Mat corpImg;
                    RotatePlate(image, out corpImg, candidates[i]); // RotatePlate method as defined before

                    Cv2.CvtColor(corpImg, corpImg, ColorConversionCodes.BGR2GRAY);
                    Cv2.Resize(corpImg, corpImg, new OpenCvSharp.Size(144, 28), 0, 0, InterpolationFlags.Cubic);

                    candidatesImg.Add(corpImg);
                }
                else
                {
                    // Remove the candidate if it does not verify as a plate
                    candidates.RemoveAt(i);
                    i--; // Decrement the index to account for the removed candidate
                }
            }

            return candidatesImg;
        }


        public void RefineCandidate(Mat image, RotatedRect candi, List<RotatedRect> candidates)
        {
            Mat fill = new Mat(image.Rows + 2, image.Cols + 2, MatType.CV_8UC1, Scalar.All(0));
            Scalar diff1 = new Scalar(25, 25, 25);
            Scalar diff2 = new Scalar(25, 25, 25);
            FloodFillFlags flags = FloodFillFlags.Link8 | FloodFillFlags.FixedRange | FloodFillFlags.MaskOnly;

            Point2f[] randPt = new Point2f[15];
            var rng = new RNG();
            for (int i = 0; i < randPt.Length; i++)
            {
                randPt[i] = new Point2f((float)rng.Uniform(0, 7), (float)rng.Uniform(0, 7));
            }

            Rect imgRect = new Rect(0, 0, image.Cols, image.Rows);

            for (int i = 0; i < randPt.Length; i++)
            {
                Point2f seed = candi.Center + randPt[i];
                OpenCvSharp.Point seedPoint = new OpenCvSharp.Point((int)seed.X, (int)seed.Y);

                if (imgRect.Contains(seedPoint))
                {
                    Cv2.FloodFill(image, fill, seedPoint, Scalar.All(0), out _, diff1, diff2, flags);
                }
            }

            List<OpenCvSharp.Point> fillPts = new List<OpenCvSharp.Point>();
            for (int i = 0; i < fill.Rows; i++)
            {
                for (int j = 0; j < fill.Cols; j++)
                {
                    if (fill.At<byte>(i, j) == 255)
                    {
                        fillPts.Add(new OpenCvSharp.Point(j, i));
                    }
                }
            }

            if (fillPts.Count > 0)
            {
                candidates.Add(Cv2.MinAreaRect(fillPts.ToArray()));
            }

            foreach (var refinedCandidate in candidates)
            {
                DrawRotatedRect(image, refinedCandidate, Scalar.Blue, 2);
            }
        }




        public void RotatePlate(Mat image, out Mat corpImg, RotatedRect candi)
        {
            corpImg = new Mat();

            float aspect = (float)candi.Size.Width / candi.Size.Height;
            float angle = candi.Angle;

            if (aspect < 1)
            {
                candi.Size = new OpenCvSharp.Size((int)Math.Round(candi.Size.Height), (int)Math.Round(candi.Size.Width));
                angle += 90;
            }

            Mat rotMat = Cv2.GetRotationMatrix2D(candi.Center, angle, 1);
            Cv2.WarpAffine(image, corpImg, rotMat, image.Size(), InterpolationFlags.Cubic);

            OpenCvSharp.Size size = new OpenCvSharp.Size((int)Math.Round(candi.Size.Width), (int)Math.Round(candi.Size.Height));
            Cv2.GetRectSubPix(corpImg, size, candi.Center, corpImg);
        }
        private Mat CropImage(Mat originalImage, RotatedRect region)
        {
            // 회전된 직사각형의 꼭짓점을 얻어옵니다.
            Point2f[] rectPoints = region.Points();

            // 회전된 직사각형을 감싸는 최소 크기의 사각형을 얻어옵니다.
            Rect boundingRect = Cv2.BoundingRect(rectPoints);

            // 최소 크기 사각형을 벗어난 부분은 자르기 위해 크기를 조정합니다.
            boundingRect.X = Math.Max(boundingRect.X, 0);
            boundingRect.Y = Math.Max(boundingRect.Y, 0);
            boundingRect.Width = Math.Min(boundingRect.Width, originalImage.Width - boundingRect.X);
            boundingRect.Height = Math.Min(boundingRect.Height, originalImage.Height - boundingRect.Y);

            // 원본 이미지에서 해당 영역을 자릅니다.
            Mat croppedImage = new Mat(originalImage, boundingRect);

            return croppedImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int carNo = int.Parse(textBox1.Text);
            string imagePath = $"C:\\Temp\\img\\{carNo:D2}.jpg";
            image = new Mat(imagePath, ImreadModes.Color);

            if (image.Empty())
            {
                MessageBox.Show("이미지를 읽을 수 없습니다.");
                return;
            }

            Mat morph = Preprocessing(image);
            List<RotatedRect> candidates = new List<RotatedRect>();
            FindCandidates(morph, candidates);

            List<RotatedRect> refinedCandidates = new List<RotatedRect>();
            foreach (var candidate in candidates)
            {
                RefineCandidate(image, candidate, refinedCandidates);
            }

            foreach (var refinedCandidate in refinedCandidates)
            {
                DrawRotatedRect(image, refinedCandidate, Scalar.Blue, 2);

                // 정제된 후보를 감싸는 영역을 자른 이미지를 얻어옵니다.
                Mat croppedImage = CropImage(image, refinedCandidate);

                // 자른 이미지를 pictureBox2에 표시
                pictureBox2.Image = BitmapConverter.ToBitmap(croppedImage);
            }

            // 원본 이미지를 pictureBox1에 표시
            pictureBox1.Image = BitmapConverter.ToBitmap(image);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 2 클릭!");
        }
    }
}