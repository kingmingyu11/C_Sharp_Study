using Microsoft.AspNetCore.Mvc;

namespace Webempty_test1
{
    public class MyController : Controller
    {
        [Route("/")]
        public IActionResult Help()
        {
            return View();
        }
    }
}
