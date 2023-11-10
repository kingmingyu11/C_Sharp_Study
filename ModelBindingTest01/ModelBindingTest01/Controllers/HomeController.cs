using Microsoft.AspNetCore.Mvc;
using ModelBindingTest01.Models;
using System.Diagnostics;

namespace ModelBindingTest01.Controllers
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
        [HttpGet]

       
        public string About(int id,string name)
        {
            return "ID :" + id + "Name:" + name;
        }
        [HttpPost]
        public string Index(Student st)
        {
            return "Id :" + st.ID+ "Name" +st.Name +"Hp :" + st.Hp;
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