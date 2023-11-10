using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Views.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
