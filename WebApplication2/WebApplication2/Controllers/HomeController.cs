using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;
using System;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Mat src = Cv2.ImRead("C:\\Temp\\img\\tomato.jpg");
            Mat hsv = new Mat(src.Size(), MatType.CV_8UC3);
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            // BGR --> HSV
            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);
            // HSV 각각 채널을 분리
            // Hue(색상) : 색깔에 해당하는 시각적 감각의 속성
            // Saturation(채도) : 색상의 깊이로 얼마나 순수한 색상이냐를 구분
            // Value(명도) : 밝고 어두운 정도인데 명도가 높을수록 인식률이 좋다.
            Mat[] HSV = Cv2.Split(hsv);
            Mat H_blue = new Mat(src.Size(), MatType.CV_8UC1);
            Mat H_red = new Mat(src.Size(), MatType.CV_8UC1);
            Cv2.InRange(HSV[0], new Scalar(110, 100, 100), new Scalar(130, 255, 255), H_blue);  // blue
            Cv2.InRange(HSV[0], new Scalar(0, 100, 100), new Scalar(5, 255, 255), H_red);  // red

            Mat result = new Mat(src.Size(), MatType.CV_8UC3);
            Cv2.BitwiseOr(H_blue, H_red, result);    //
            Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);// Cv2에서는 BGR 형태만 입력가능, 그렇기에 다시 HSV --> BGR


            Cv2.BitwiseAnd(src, src, dst, result);

            ViewBag.Tomato = dst;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}