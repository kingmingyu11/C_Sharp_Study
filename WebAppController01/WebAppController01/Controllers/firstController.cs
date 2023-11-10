using Microsoft.AspNetCore.Mvc;

namespace WebAppController01.Controllers
{
    public class firstController : Controller
    {
        [Route("First")]
        public IActionResult First()
        {
            return View();
        }
    
    }
}
