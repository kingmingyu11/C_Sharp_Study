using Microsoft.AspNetCore.Mvc;

namespace WebEmpty_Layout.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("/About")]
        public IActionResult About()
        {
            return View();
        }
    }
}
