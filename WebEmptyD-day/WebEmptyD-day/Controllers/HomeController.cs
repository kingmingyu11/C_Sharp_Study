using Microsoft.AspNetCore.Mvc;

namespace WebEmptyD_day.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult index(DateTime number1, DateTime number2)
        {

            ViewBag.Result =(number2 - number1).ToString("dd");
            return View();
        }
    }
}
