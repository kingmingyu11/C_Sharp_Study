using Microsoft.AspNetCore.Mvc;
using OpenCvSharp;
using REdblueTomato.Models;
using System.Diagnostics;

namespace REdblueTomato.Controllers
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


            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);

            Mat[] HSV = Cv2.Split(hsv);
            Mat H_blue = new Mat(src.Size(), MatType.CV_8UC1);
            Mat H_red = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.InRange(HSV[0], new Scalar(110, 100, 100), new Scalar(130, 255, 255), H_blue);//blue
            Cv2.InRange(HSV[0], new Scalar(0, 100, 100), new Scalar(5, 255, 255), H_red);//blue

            Mat result = new Mat(src.Size(), MatType.CV_8UC3);
            Cv2.BitwiseOr(H_blue,H_red, result);
            Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);

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