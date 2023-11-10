using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TypedviewTest.Models;

namespace TypedviewTest.Controllers
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
            var students = new List<Student>
            {
                new Student { Id = 1,Name = "홍길동",Hp ="010-1111-1111"},
                new Student { Id = 2,Name = "이순신",Hp ="010-2222-1111"},
                new Student { Id = 3,Name = "강감찬",Hp ="010-3333-1111"}

            };
            return View(students);
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