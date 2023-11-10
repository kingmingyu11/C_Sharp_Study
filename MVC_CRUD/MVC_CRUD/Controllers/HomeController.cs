using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using System.Diagnostics;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext _studentDb;

        public HomeController(StudentDbContext studentDb)
        {
            _studentDb = studentDb;
        }
        public IActionResult Index()
        {
            var stdData = _studentDb.Student.ToList();
            return View(stdData);
        }
        //Get 화면
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //POST: 삽입기능
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Hp")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentDb.Add(student);
                await _studentDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}