using Microsoft.AspNetCore.Mvc;
using MVC_model2.Models;
using MVC_model2.Repository;
using System.Diagnostics;

namespace MVC_model2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentRepository _studentRepository = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _studentRepository = new StudentRepository();
        }
        public List<StudentModel> 
            ()
        {
            return _studentRepository.GetAllStudents();
        }
        public StudentModel getStudent(int id)
        {
            return _studentRepository.getStudentById(id);
        }
        public IActionResult Index()
        {
            //var st = new StudentModel()
            //{
            //    ID = 1,
            //    Name = "홍길동",
            //    HP = "010-1111-1111",
            //    Major = " 컴공"
            //};
            //ViewData["data1"] = st;

            //var students = new List<StudentModel>()
            //{
            //    new StudentModel{ ID=1, Name= "홍길동", HP = "010-1111-1111", Major = "컴공" },
            //    new StudentModel{ ID=1, Name= "이순신", HP = "010-2222-2222", Major = "정통" },
            //    new StudentModel{ ID=1, Name= "강감찬", HP = "010-3333-3333", Major = "기계" }

            //};
            //ViewData["data1"] = students;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}