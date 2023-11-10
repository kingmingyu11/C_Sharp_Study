using Microsoft.AspNetCore.Mvc;
using MVC_Model1.Models;
using System.Diagnostics;

namespace MVC_Model1.Controllers
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
            var st1 = new StudentModel()
            {
                ID = 1,
                Name = "홍길동",
                HP = "010-1111-1111",
            Major = "컴퓨터공학과"
            };
           //ViewData["student"] = st1;
           ViewBag.data1= st1;
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