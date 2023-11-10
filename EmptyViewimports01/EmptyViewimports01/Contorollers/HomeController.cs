using EmptyViewimports01.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmptyViewimports01.Contorollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var students1 = new List<students>
            {
                new students {Id = 1 , Name = "홍길동",Hp="010-111-111"},
                new students {Id = 2 , Name = "강감찬",Hp="010-111-111"},
                new students {Id = 3 , Name = "이순신",Hp="010-111-111"},

            };
            return View(students1);
        }
        public IActionResult About()
        {
            var students1 = new List<students>
            {
                new students {Id = 1 , Name = "홍길동",Hp="010-111-111"},
                new students {Id = 2 , Name = "강감찬",Hp="010-111-111"},
                new students {Id = 3 , Name = "이순신",Hp="010-111-111"},

            };
            return View(students1);
        }
    }
}
