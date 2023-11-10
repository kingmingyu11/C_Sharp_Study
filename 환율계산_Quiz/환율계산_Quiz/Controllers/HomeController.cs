using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using 환율계산_Quiz.Models;

namespace 환율계산_Quiz.Controllers
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
            return View();

        }
        [HttpPost]
        
        public IActionResult Index(double number1)
        {
            double dollar = number1 * 0.075;
            double uro = number1 * 0.069;

            ViewBag.Result1=dollar;
            ViewBag.Result2=uro;
            
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