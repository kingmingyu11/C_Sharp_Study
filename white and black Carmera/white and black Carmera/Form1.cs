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
using System.Windows.Forms.VisualStyles;

namespace white_and_black_Carmera
{
    public partial class Form1 : Form
    {
        private VideoCapture capture; //카메라 캡처 객체
        private Mat frame;            //현재 프레임을 저장할 객체
        private bool isRunning = false; //카메라가 실행 중인지 확인하는 변수
        private bool isColor = true;    //컬러 모드인지 확인하는 변수
        private bool isBlurred = false;
        private bool applyFisheyeEffect = false;
        private bool applyConvexEffect = false;
        private bool isSharpened = false;
        private bool applyCannyEdgeDetection = false;
        private bool applyHistogramEqualization = false;
        private int zoomLevel = 100;
        private double focalLength = 200.0; // 초점 거리 (조정 가능)
        private double distortionCoefficient = 0.5;

        public object HaarDetectionType { get; private set; }

        public Form1()
        {
            InitializeComponent();
           
        }
        private void ApplyFisheye(Mat input, Mat output)
        {
            Mat cameraMatrix = Mat.Eye(3, 3, MatType.CV_64FC1);
            cameraMatrix.At<double>(0, 0) = focalLength;
            cameraMatrix.At<double>(1, 1) = focalLength;
            cameraMatrix.At<double>(0, 2) = input.Cols / 2.0 ;
            cameraMatrix.At<double>(1, 2) = input.Rows / 2.0;

            Mat distCoeffs = new Mat(4, 1, MatType.CV_64FC1);
            distCoeffs.SetTo(0);
            distCoeffs.At<double>(0, 0) = distortionCoefficient;

            // 오목렌즈 효과를 적용합니다.
            Cv2.Undistort(input, output, cameraMatrix, distCoeffs);
        }
        private void ApplyConvex(Mat input, Mat output)
        {
            // 카메라 매트릭스와 왜곡 계수를 정의합니다.
            Mat cameraMatrix = Mat.Eye(3, 3, MatType.CV_64FC1);
            cameraMatrix.At<double>(0, 0) = focalLength;
            cameraMatrix.At<double>(1, 1) = focalLength;
            cameraMatrix.At<double>(0, 2) = input.Cols / 2.0;
            cameraMatrix.At<double>(1, 2) = input.Rows / 2.0;

            Mat distCoeffs = new Mat(4, 1, MatType.CV_64FC1);
            distCoeffs.SetTo(0);
            distCoeffs.At<double>(0, 0) = -distortionCoefficient; // 볼록렌즈 효과를 위해 음수 값 사용

            // 볼록렌즈 효과를 적용합니다.
            Cv2.Undistort(input, output, cameraMatrix, distCoeffs);
        }
        private void DetectAndDrawFaces(Mat frame)
        {
            using (CascadeClassifier faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml"))
            using (Mat ugray = new Mat())
            {
                Cv2.CvtColor(frame, ugray, ColorConversionCodes.BGR2GRAY);
                Cv2.EqualizeHist(ugray, ugray);

                Rect[] faces = faceCascade.DetectMultiScale(
                    ugray,
                    1.1,
                    5,
                    0,
                    new OpenCvSharp.Size(30, 30));

                foreach (Rect face in faces)
                {
                    Cv2.Rectangle(frame, face, new Scalar(0, 0, 255), 2);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);  //카메라 장치 연결
            frame = new Mat();
            capture.Set(VideoCaptureProperties.FrameWidth, 640); //프레임 너비 설정
            capture.Set(VideoCaptureProperties.FrameHeight, 480); // 프레임 높이 설정
                                                                  // TrackBar 초기화
            trackBar1.Minimum = 0; // 최소 줌 레벨
            trackBar1.Maximum = 200; // 최대 줌 레벨 (100%까지 확대, 0%로 축소)
            trackBar1.Value = zoomLevel; // 초기값 설정
            trackBar1.TickFrequency = 10; //
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                button1.Text = "Start";
            }
            else
            {
                isRunning = true;
                button1.Text = "Stop";

                //capture = new VideoCapture(0);
                //frame = new Mat();

                while (isRunning)
                {
                    if (capture.IsOpened())
                    {
                        capture.Read(frame);

                        if (!isColor)
                        {
                            Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);
                            Cv2.CvtColor(frame, frame, ColorConversionCodes.GRAY2BGR);
                        }

                        Mat processedFrame = frame.Clone();

                        if (applyFisheyeEffect)
                        {
                            Mat fisheyeFrame = new Mat();
                            ApplyFisheye(processedFrame, fisheyeFrame);
                            processedFrame = fisheyeFrame;
                        }
                        else if (applyConvexEffect)
                        {
                            Mat convexFrame = new Mat();
                            ApplyConvex(processedFrame, convexFrame);
                            processedFrame = convexFrame;
                        }
                        if (isSharpened)
                        {
                            // 샤프닝 효과를 적용
                            Mat sharpeningKernel = new Mat(3, 3, MatType.CV_32F, new float[9] { 0, -1, 0, -1, 5, -1, 0, -1, 0 });
                            Cv2.Filter2D(processedFrame, processedFrame, processedFrame.Type(), sharpeningKernel, new OpenCvSharp.Point(0, 0));
                        }

                        if (isBlurred)
                        {
                            Cv2.GaussianBlur(processedFrame, processedFrame, new OpenCvSharp.Size(15, 15), 10, 10, BorderTypes.Default);
                        }
                        if (applyCannyEdgeDetection)
                        {
                            // 캐니 엣지 검출을 적용
                            Cv2.CvtColor(processedFrame, processedFrame, ColorConversionCodes.BGR2GRAY);
                            Cv2.Canny(processedFrame, processedFrame, 100, 200);
                            Cv2.CvtColor(processedFrame, processedFrame, ColorConversionCodes.GRAY2BGR);
                        }
                        if (applyHistogramEqualization)
                        {
                            // 히스토그램 평활화를 적용
                            Cv2.CvtColor(processedFrame, processedFrame, ColorConversionCodes.BGR2GRAY);
                            Cv2.EqualizeHist(processedFrame, processedFrame);
                            Cv2.CvtColor(processedFrame, processedFrame, ColorConversionCodes.GRAY2BGR);
                        }
                        
                        DetectAndDrawFaces(processedFrame); // 얼굴 감지 함수 호출
                        pictureBox1.Image = BitmapConverter.ToBitmap(processedFrame);
                    }
                    await Task.Delay(33);
                }
                capture.Release();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            isColor = false;  // 흑백 모드로 변경


        }

        private void button3_Click(object sender, EventArgs e)
        {
            isColor = true;  // 흑백 모드로 변경

        }

        private void button4_Click(object sender, EventArgs e)
        {
            isRunning = false;  // 카메라 중지
            capture.Release();  // 카메라 자원 해제
            this.Close();       // 프로그램 종료
        }

        private void button5_Click(object sender, EventArgs e)
        {


            isBlurred = !isBlurred;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            applyFisheyeEffect = !applyFisheyeEffect;   // 오목렌즈 효과 활성화
            applyConvexEffect = false;   // 볼록렌즈 효과 비활성화
        }
        private void button7_Click(object sender, EventArgs e)
        {
            applyConvexEffect = !applyConvexEffect;
            applyFisheyeEffect = false;   // 오목렌즈 효과 활성화
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            isSharpened = !isSharpened; // 버튼을 클릭할 때 샤프닝 상태를 토글

        }

        private void button9_Click(object sender, EventArgs e)
        {
            applyCannyEdgeDetection = !applyCannyEdgeDetection;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            applyHistogramEqualization = !applyHistogramEqualization;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Mat zoomedFrame = frame.Clone();

            capture.Set(VideoCaptureProperties.Zoom, zoomLevel / 100.0);
            int width = (int)(frame.Cols * zoomLevel / 100);
            int height = (int)(frame.Rows * zoomLevel / 100);
            int x = (frame.Cols - width) / 2;
            int y = (frame.Rows - height) / 2;
            Rect zoomedRect = new Rect(x, y, width, height);

            // 새로운 Mat에 부분을 복사
            frame[zoomedRect].CopyTo(zoomedFrame);

            // 이미지 업데이트
            pictureBox1.Image = BitmapConverter.ToBitmap(zoomedFrame);
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
