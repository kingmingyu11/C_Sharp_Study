using Microsoft.AspNetCore.Mvc;
using OpenCV.Models;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;
using System.Xml.Linq;
using System.Collections.Generic;

namespace OpenCV.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult GetImage(int number)
        {
            if (number == 0)
            {
                return Content("이미지 처리를 종료합니다.");
            }

            string imagePath = $"C:\\Temp\\img\\{number:D2}.jpg";

            if (!System.IO.File.Exists(imagePath))
            {
                return Content($"{number}번 차량이 없습니다.");
            }

            Mat image = Cv2.ImRead(imagePath, ImreadModes.Color);
            Mat gray = new Mat();

            // 이미지 전처리
            Cv2.GaussianBlur(image, gray, new OpenCvSharp.Size(5, 5), 0);
            Cv2.CvtColor(gray, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, gray, 120, 255, ThresholdTypes.Binary);

            // Canny 엣지 검출
            Cv2.Canny(gray, gray, 100, 100, 3);

            // Find contours (윤곽선 찾기)
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(gray, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, new OpenCvSharp.Point(0, 0));

            // Variables to store the filtered rectangles (필터링된 사각형 저장을 위한 변수)
            List<RotatedRect> filteredRectangles = new List<RotatedRect>();

            for (int i = 0; i < contours.Length; i++)
            {
                RotatedRect rotatedRect = Cv2.MinAreaRect(contours[i]);
                Rect boundingRect = rotatedRect.BoundingRect();

                double ratio = (double)boundingRect.Height / boundingRect.Width;

                // Filtering rectangles based on height/width ratio and area (높이/너비 비율과 면적에 따라 사각형 필터링)
                if (ratio <= 3.0 && ratio >= 0.3 && Cv2.ContourArea(contours[i]) <= 700 && Cv2.ContourArea(contours[i]) >= 100)
                {
                    // 주석 처리한 라인들을 제거하고 결과를 확인해봐
                    Cv2.DrawContours(gray, contours, i, new Scalar(255, 255, 255), 1);
                    Cv2.Rectangle(gray, boundingRect, new Scalar(255, 255, 255), 1);

                    // Store suitable rectangles (적합한 사각형 저장)
                    filteredRectangles.Add(rotatedRect);
                }
               
             
                
            }

            // 이미지를 JPEG 바이트 배열로 변환하여 반환
            var imageBytesWithContours = gray.ToBytes(".jpg");

            return File(imageBytesWithContours, "image/jpeg");
        }
        private bool IsSuitableRectangle(RotatedRect rotatedRect)
        {
            // 적합한 사각형 필터링 조건을 정의
            double ratio = (double)rotatedRect.Size.Height / rotatedRect.Size.Width;
            double area = rotatedRect.Size.Height * rotatedRect.Size.Width;

            return (ratio <= 6 && ratio >= 0.1 && area <= 1000 && area >= 200) ||
                   (ratio <= 2 && ratio >= 0.1 && area <= 5000 && area >= 100) ||
                   (ratio <= 1.5 && ratio >= 0.5 && area <= 8000 && area >= 50);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
