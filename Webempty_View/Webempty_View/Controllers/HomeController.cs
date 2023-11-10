using Microsoft.AspNetCore.Mvc;

namespace Webempty_View.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/about")]

        public IActionResult About()
        {
            return View();
        }
    }
}
