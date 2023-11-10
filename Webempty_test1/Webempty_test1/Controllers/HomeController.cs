using Microsoft.AspNetCore.Mvc;

namespace Webempty_test1.Controllers
{
    public class HomeController : Controller
    {
        [Route("Index")]
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
