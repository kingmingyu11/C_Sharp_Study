using Microsoft.AspNetCore.Mvc;

namespace WebEmpty_Layout.Controllers
{
    public class AboutController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
