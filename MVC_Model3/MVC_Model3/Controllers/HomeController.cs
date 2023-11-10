using Microsoft.AspNetCore.Mvc;
using MVC_Model3.Models;
using System.Diagnostics;

namespace MVC_Model3.Controllers
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
            var cars = new List<Car>()
            {
                new Car{ Id = 1,Brand = "KIa",Speed=150},
                new Car{ Id = 2,Brand = "Hyundai",Speed=160},
                new Car{ Id = 3,Brand = "ssangyoung",Speed=170}

            };
            ViewData["data1"] = cars;
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