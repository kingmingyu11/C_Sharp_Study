using Microsoft.AspNetCore.Mvc;

namespace WebEmpty_Quiz.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Day")]
        public IActionResult Day()
        {
            return View();
        }
    }
}
