using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace CameraApp
{
    public partial class Form1 : Form
    {
        private VideoCapture capture; //카메라 캡처 객체
        private Mat frame;            //현재 프레임을 저장할 객체
        private Mat processedFrame;    // 이미지 처리를 위한 객체
        private bool isRunning = false; //카메라가 실행 중인지 확인하는 변수
        private bool isColor = true;    //컬러 모드인지 확인하는 변수
        private bool applyFisheyeEffect = false; // 오목
        private bool applyConvexEffect = false; // 볼록
        private bool isBlurred = false; // Blur
        private bool isSharpened = false; // Sharpened
        private bool applyCannyEdgeDetection = false; // CannyEdge
        private bool isHistogramEqualizationEnabled = false;

        private bool Image1Displayed = false;
        private bool Image2Displayed = false;
        private bool Image3Displayed = false;

        // 선택된 오버레이 이미지
        private Image selectedOverlayImage1;
        private Image selectedOverlayImage2;
        private Image selectedOverlayImage3;

        private CascadeClassifier faceCascade;
        private double focalLength = 200.0; // 초점 거리 (조정 가능)
        private double distortionCoefficient = 0.5;

        private Image overlayImage;
        private Label countdownLabel;

        private bool isMosaicEnabled = false; // 모자이크 활성화 여부
        private System.Windows.Forms.Timer mosaicTimer; // Timer 객체를 필드로 정의

        public object HaarDetectionType { get; private set; }

        public Form1()
        {
            InitializeComponent();
            faceCascade = new CascadeClassifier("haarcascade_frontalface_default.xml");
            countdownLabel = new Label();
            mosaicTimer = new System.Windows.Forms.Timer();
            mosaicTimer.Interval = 100; // 모자이크 업데이트 간격 (예: 100ms)
            mosaicTimer.Tick += MosaicTimer_Tick;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            capture = new VideoCapture(0);  //카메라 장치 연결
            frame = new Mat();
            processedFrame = new Mat();  // processedFrame을 초기화
            capture.Set(VideoCaptureProperties.FrameWidth, 640); //프레임 너비 설정
            capture.Set(VideoCaptureProperties.FrameHeight, 480); // 프레임 높이 설정

            pictureBox1.Paint += PictureBox1_Paint; // Paint 이벤트 핸들러 추가
            countdownLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            countdownLabel.ForeColor = Color.Red;
        }
        // 오목 렌즈
        private void ApplyFisheye(Mat input, Mat output)
        {
            Mat cameraMatrix = Mat.Eye(3, 3, MatType.CV_64FC1);
            cameraMatrix.At<double>(0, 0) = focalLength;
            cameraMatrix.At<double>(1, 1) = focalLength;
            cameraMatrix.At<double>(0, 2) = input.Cols / 2.0;
            cameraMatrix.At<double>(1, 2) = input.Rows / 2.0;

            Mat distCoeffs = new Mat(4, 1, MatType.CV_64FC1);
            distCoeffs.SetTo(0);
            distCoeffs.At<double>(0, 0) = distortionCoefficient;

            // 오목렌즈 효과를 적용
            Cv2.Undistort(input, output, cameraMatrix, distCoeffs);
        }
        // 볼록 렌즈
        private void ApplyConvex(Mat input, Mat output)
        {
            // 카메라 매트릭스와 왜곡 계수를 정의
            Mat cameraMatrix = Mat.Eye(3, 3, MatType.CV_64FC1);
            cameraMatrix.At<double>(0, 0) = focalLength;
            cameraMatrix.At<double>(1, 1) = focalLength;
            cameraMatrix.At<double>(0, 2) = input.Cols / 2.0;
            cameraMatrix.At<double>(1, 2) = input.Rows / 2.0;

            Mat distCoeffs = new Mat(4, 1, MatType.CV_64FC1);
            distCoeffs.SetTo(0);
            distCoeffs.At<double>(0, 0) = -distortionCoefficient; // 볼록렌즈 효과를 위해 음수 값 사용

            // 볼록렌즈 효과 적용
            Cv2.Undistort(input, output, cameraMatrix, distCoeffs);
        }
        // 얼굴 인식
        private void DetectAndDrawFaces(Mat frame)
        {
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
        // Among / 이미지 출력
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (frame != null)
            {
                var faces = faceCascade.DetectMultiScale(frame, 1.1, 4);


                foreach (var face in faces)
                {
                    if (Image1Displayed && selectedOverlayImage1 != null)
                    {
                        e.Graphics.DrawImage(selectedOverlayImage1, face.X + 50, face.Y - 80);
                    }

                    if (Image2Displayed && selectedOverlayImage2 != null)
                    {
                        e.Graphics.DrawImage(selectedOverlayImage2, face.X + 20, face.Y + 50);
                    }
                    if (Image3Displayed && selectedOverlayImage3 != null)
                    {
                        e.Graphics.DrawImage(selectedOverlayImage3, face.X + 20, face.Y + 100);
                    }

                    // ... 다른 체크박스에 대한 코드를 이곳에 추가 ...
                }
            }
        }
        // 히스토그램 평활화
        private void ApplyHistogramEqualization(Mat frame)
        {
            if (isColor)
            {
                Mat ycrcbImage = new Mat();
                Cv2.CvtColor(frame, ycrcbImage, ColorConversionCodes.BGR2YCrCb); // BGR 영상을 YCrCb 색 공간으로 변환

                Mat[] channels = Cv2.Split(ycrcbImage);

                // 명도 채널 (Y)에 대해서만 히스토그램 평활화 적용
                Cv2.EqualizeHist(channels[0], channels[0]);

                Cv2.Merge(channels, ycrcbImage);

                // YCrCb 영상을 다시 BGR로 변환
                Cv2.CvtColor(ycrcbImage, frame, ColorConversionCodes.YCrCb2BGR);
            }
            else
            {
                Mat grayFrame = new Mat();
                Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);
                Cv2.EqualizeHist(grayFrame, grayFrame);
                Cv2.CvtColor(grayFrame, frame, ColorConversionCodes.GRAY2BGR);
            }
        }

        // 3초 후 사진 촬영 및 저장
        private async Task CaptureFrameAsync()
        {
            if (capture.IsOpened())
            {
                capture.Read(frame);

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All Files|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileName = saveFileDialog.FileName;
                        frame.ToBitmap().Save(fileName);
                    }
                }
            }
        }
        private void CaptureAndSaveImage()
        {
            if (pictureBox1.Image != null)
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All Files|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileName = saveFileDialog.FileName;
                        var imageToSave = new Bitmap(pictureBox1.Image); // pictureBox1에 표시된 이미지를 복사
                        imageToSave.Save(fileName);
                    }
                }
            }
        }

        private async void CaptureAndSaveImageWithDelay()
        {
            // 3초 대기를 시작하기 전에 화면에 "3"을 표시
            countdownLabel.Text = "3";
            await Task.Delay(1000); // 1초 대기
            countdownLabel.Text = "2";
            await Task.Delay(1000); // 1초 대기
            countdownLabel.Text = "1";
            await Task.Delay(1000); // 1초 대기
            countdownLabel.Text = "0";

            if (pictureBox1.Image != null)
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All Files|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileName = saveFileDialog.FileName;
                        var imageToSave = new Bitmap(pictureBox1.Image); // pictureBox1에 표시된 이미지를 복사
                        imageToSave.Save(fileName);
                    }
                }
            }
        }

        //=============================================================================================================================================================
        //=============================================================================================================================================================
        // Start 버튼
        private async void button1_Click(object sender, EventArgs e)
        {
            if (isRunning) // 이미 카메라가 실행중이면
            {
                isRunning = false; //실행중 상태를 false로 변경
                button1.Text = "Start"; //버튼 텍스트 변경
                return;
            }
            button1.Text = "Stop"; // 버튼 텍스트 변경
            isRunning = true; // 카메라가 실행중이면

            while (isRunning)
            {
                if (capture.IsOpened())
                {
                    capture.Read(frame);
                    // 흑백
                    if (!isColor)
                    {
                        Cv2.CvtColor(frame, frame, ColorConversionCodes.BGR2GRAY);
                        Cv2.CvtColor(frame, frame, ColorConversionCodes.GRAY2BGR);
                    }

                    processedFrame = frame.Clone();

                    if (isMosaicEnabled)
                    {
                        ApplyMosaicEffect(processedFrame); // 모자이크 효과 적용
                    }

                    // 오목
                    if (applyFisheyeEffect)
                    {
                        Mat fisheyeFrame = new Mat();
                        ApplyFisheye(processedFrame, fisheyeFrame);
                        processedFrame = fisheyeFrame;
                    }
                    // 볼록
                    else if (applyConvexEffect)
                    {
                        Mat convexFrame = new Mat();
                        ApplyConvex(processedFrame, convexFrame);
                        processedFrame = convexFrame;
                    }
                    // 블러
                    if (isBlurred)
                    {
                        Cv2.GaussianBlur(processedFrame, processedFrame, new OpenCvSharp.Size(15, 15), 10, 10, BorderTypes.Default);
                    }
                    // 샤프닝
                    if (isSharpened)
                    {
                        // 샤프닝 효과를 적용
                        Mat sharpeningKernel = new Mat(3, 3, MatType.CV_32F, new float[9] { 0, -1, 0, -1, 5, -1, 0, -1, 0 });
                        Cv2.Filter2D(processedFrame, processedFrame, processedFrame.Type(), sharpeningKernel, new OpenCvSharp.Point(0, 0));
                    }
                    // 캐니 엣지
                    if (applyCannyEdgeDetection)
                    {
                        // 캐니 엣지 검출을 적용
                        Cv2.CvtColor(processedFrame, processedFrame, ColorConversionCodes.BGR2GRAY);
                        Cv2.Canny(processedFrame, processedFrame, 100, 200);
                        Cv2.CvtColor(processedFrame, processedFrame, ColorConversionCodes.GRAY2BGR);
                    }
                    if (isMosaicEnabled)
                    {
                        MosaicTimer_Tick(null, null); // 모자이크 효과 적용
                    }
                    if (isHistogramEqualizationEnabled)
                    {
                        ApplyHistogramEqualization(processedFrame);
                    }

                    DetectAndDrawFaces(processedFrame); // 얼굴 감지 함수 호출
                    pictureBox1.Image = BitmapConverter.ToBitmap(processedFrame);
                }
                await Task.Delay(33);
            }
        }

        //=============================================================================================================================================================
        //=============================================================================================================================================================
        // gray 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            isColor = false;  // 흑백 모드로 변경
        }
        // color 버튼
        private void button3_Click(object sender, EventArgs e)
        {
            isColor = true;  // 흑백 모드로 변경
        }
        // EXit 버튼
        private void button4_Click(object sender, EventArgs e)
        {
            isRunning = false;  // 카메라 중지
            capture.Release();  // 카메라 자원 해제
            this.Close();       // 프로그램 종료
        }
        // omok 버튼
        private void button5_Click(object sender, EventArgs e)
        {
            applyFisheyeEffect = !applyFisheyeEffect;
        }
        // bolrok 버튼
        private void button6_Click(object sender, EventArgs e)
        {
            applyConvexEffect = !applyConvexEffect; // 볼록렌즈 효과 활성화
            applyFisheyeEffect = false;    // 오목렌즈 효과 비활성화
        }
        // Original 버튼
        private void button7_Click(object sender, EventArgs e)
        {
            applyFisheyeEffect = false;    // 오목렌즈 효과 비활성화
            applyConvexEffect = false;     // 볼록렌즈 효과 비활성화
            isBlurred = false;             // 블러 효과 비활성화
            isSharpened = false;           // 샤프닝 효과 비활성화         
            applyCannyEdgeDetection = false;            // 캐니에지 효과 비활성화
            isHistogramEqualizationEnabled = false;         // 평활화 효과 비활성화

            selectedOverlayImage1 = null;
            selectedOverlayImage2 = null;
            selectedOverlayImage3 = null;

            isMosaicEnabled = false; // 모자이크 비활성화
            mosaicTimer.Stop();

            isColor = true;
            isRunning = true;
        }
        // Blur 버튼
        private void button8_Click(object sender, EventArgs e)
        {
            isBlurred = !isBlurred;
        }
        // Sharpening 버튼
        private void button9_Click(object sender, EventArgs e)
        {
            isSharpened = !isSharpened;
        }

        private void MosaicTimer_Tick(object sender, EventArgs e)
        {
            if (isMosaicEnabled)
            {
                double scaleFactor = 0.1;  // 이미지 축소 비율
                double scaleUpFactor = 10.0;  // 이미지 확대 비율

                // 이미지 처리를 활성화한 경우 확대/축소 효과 적용
                Mat resultImage = processedFrame.Clone();
                Cv2.Resize(resultImage, resultImage, new OpenCvSharp.Size(resultImage.Width * scaleFactor, resultImage.Height * scaleFactor), interpolation: InterpolationFlags.Lanczos4);
                Cv2.Resize(resultImage, resultImage, new OpenCvSharp.Size(resultImage.Width * scaleUpFactor, resultImage.Height * scaleUpFactor), interpolation: InterpolationFlags.Lanczos4);

                // 모자이크 효과 적용
                ApplyMosaicEffect(resultImage);

                // 화면에 모자이크 효과가 적용된 이미지 표시
                pictureBox1.Image = BitmapConverter.ToBitmap(resultImage);
            }
            else
            {
                // 이미지 처리를 비활성화한 경우 원본 이미지 표시
                pictureBox1.Image = BitmapConverter.ToBitmap(processedFrame);
            }
        }

        private void ApplyMosaicEffect(Mat frame)
        {
            int blockSize = 10; // 모자이크 블록의 크기 (조절 가능)

            // 원본 이미지 크기 저장
            int originalWidth = frame.Width;
            int originalHeight = frame.Height;

            // 축소
            Cv2.Resize(frame, frame, new OpenCvSharp.Size(originalWidth / blockSize, originalHeight / blockSize));

            // 다시 확대
            Cv2.Resize(frame, frame, new OpenCvSharp.Size(originalWidth, originalHeight), interpolation: InterpolationFlags.Nearest);

            // 이미지 픽셀 값을 일정 블록 크기로 설정 (모자이크 효과)
            for (int y = 0; y < originalHeight; y += blockSize)
            {
                for (int x = 0; x < originalWidth; x += blockSize)
                {
                    Rect roi = new Rect(x, y, blockSize, blockSize);
                    Scalar averageColor = Cv2.Mean(frame.SubMat(roi));
                    Cv2.Rectangle(frame, roi, averageColor, thickness: -1); // 모자이크 블록
                }
            }
        }

        // 모자이크
        private void button10_Click(object sender, EventArgs e)
        {
            isMosaicEnabled = !isMosaicEnabled; // 모자이크 상태를 토글

            if (isMosaicEnabled)
            {
                mosaicTimer.Start(); // 모자이크 효과 활성화
            }
            else
            {
                mosaicTimer.Stop(); // 모자이크 효과 비활성화
            }
        }

        // CannyEdge 버튼
        private void button11_Click(object sender, EventArgs e)
        {
            applyCannyEdgeDetection = !applyCannyEdgeDetection;
        }
        // Histogram 버튼
        private void button12_Click(object sender, EventArgs e)
        {
            if (isHistogramEqualizationEnabled)
            {
                isHistogramEqualizationEnabled = false; // 평활화 끄기
                button12.Text = "평활화 켜기";
            }
            else
            {
                isHistogramEqualizationEnabled = true; // 평활화 켜기
                button12.Text = "평활화 끄기";
            }
        }

        // 사진 캡쳐
        private async void button13_Click(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            if (capture.IsOpened())
            {
                await CaptureFrameAsync();
            }
        }

        // 빈칸
        private void button14_Click(object sender, EventArgs e)
        {
        }

        // 어몽어스 머리 위에 띄우기
        private void button15_Click(object sender, EventArgs e)
        {
            if (selectedOverlayImage1 == null)
            {
                selectedOverlayImage1 = Image.FromFile("C:\\Temp\\img\\among3.png");
                Image1Displayed = !Image1Displayed;
            }
            else
            {
                selectedOverlayImage1 = null;
            }
            pictureBox1.Invalidate();
        }
        // 선글라스 버튼
        private void button16_Click(object sender, EventArgs e)
        {
            if (selectedOverlayImage2 == null)
            {
                selectedOverlayImage2 = Image.FromFile("C:\\Temp\\img\\sunglass1.png");
                Image2Displayed = !Image2Displayed;
            }
            else
            {
                selectedOverlayImage2 = null;
            }
            pictureBox1.Invalidate();
        }
        // 수염 버튼
        private void button17_Click(object sender, EventArgs e)
        {
            if (selectedOverlayImage3 == null)
            {
                selectedOverlayImage3 = Image.FromFile("C:\\Temp\\img\\Rbread.png");
                Image3Displayed = !Image3Displayed;
            }
            else
            {
                selectedOverlayImage3 = null;
            }
            pictureBox1.Invalidate();
        }

        private void CapturePictureBoxContent(PictureBox pictureBox, Mat frame)
        {
            // PictureBox에 그려진 이미지와 그림을 포함하여 화면을 캡처
            using (Bitmap capturedImage = new Bitmap(pictureBox.Width, pictureBox.Height))
            {
                pictureBox.DrawToBitmap(capturedImage, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));

                // 여기에서 capturedImage를 저장하거나 추가 처리를 수행할 수 있습니다.
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All Files|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileName = saveFileDialog.FileName;
                        capturedImage.Save(fileName);
                    }
                }
            }

        }

        // 사진 찍기
        private void button18_Click(object sender, EventArgs e)
        {
            if (capture.IsOpened())
            {
                label1.Visible = true;
                label1.BackColor = Color.Transparent;
                label1.BorderStyle = BorderStyle.None;
                label1.Text = "Capturing..."; // 촬영 중임을 표시

                Mat frame = new Mat();
                capture.Read(frame);

                if (frame != null)
                {
                    // PictureBox1에 그려진 이미지와 그림을 포함하여 화면을 캡처
                    CapturePictureBoxContent(pictureBox1, frame);
                }

                label1.Text = "Capture Complete"; // 촬영 완료 메시지 표시
                Thread.Sleep(1000); // 1초 대기
                label1.Visible = false;
            }
        }

        private async Task CapturePictureBoxContentAsync(PictureBox pictureBox)
        {
            // PictureBox에 그려진 이미지와 그림을 포함하여 화면을 캡처
            using (Bitmap capturedImage = new Bitmap(pictureBox.Width, pictureBox.Height))
            {
                pictureBox.DrawToBitmap(capturedImage, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));

                // 여기에서 capturedImage를 저장하거나 추가 처리를 수행할 수 있습니다.
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|All Files|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileName = saveFileDialog.FileName;
                        capturedImage.Save(fileName);
                    }
                }
            }
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.BackColor = Color.Transparent;
            label1.BorderStyle = BorderStyle.None;
            int cnt = 0; // 시작 숫자 (5부터 시작)
            while (cnt >= 0)
            {
                label1.Text = cnt.ToString();
                await Task.Delay(1000); // 1초 대기
                cnt--;
            }
            label1.Visible = false;

            if (capture.IsOpened())
            {
                // PictureBox1에 그려진 이미지와 그림을 포함하여 화면을 캡처
                await CapturePictureBoxContentAsync(pictureBox1);
            }

        }
    }
}