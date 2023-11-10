using Microsoft.AspNetCore.Mvc;

namespace WebAppController01.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("About")]

        public IActionResult About()
        {
            return View();
        }
    }
}
