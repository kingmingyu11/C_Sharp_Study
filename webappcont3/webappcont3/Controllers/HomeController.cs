using Microsoft.AspNetCore.Mvc;

namespace webappcont3.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/About")]

        public IActionResult About()
        {
            return View();
        }
        [Route("/Details/{id?}")]
        public int Details(int id)
        {
            return id;
            
        }
    }
}
