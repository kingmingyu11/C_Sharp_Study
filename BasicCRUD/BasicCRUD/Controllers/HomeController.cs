using BasicCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BasicCRUD.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //        var students = _context.Student.ToList();
        //        return View(students);
            
        //}
        public async Task<IActionResult> Index()
        {
            var students = await _context.Student.ToListAsync<Student>();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(Student std)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        _context.Student.Add(std);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index","Home");
                   
        //    }
        //    return View(std);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
               await _context.Student.AddAsync(std);
               await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");

            }
            return View(std);
        }

        public IActionResult Details(int? id)
        {
            //if(id  == null || _context.Student == null)
            //{

            //}
            var stdData = _context.Student.FirstOrDefault(x => x.Id == id);
            return View(stdData);
        }
        //Edit 만들기

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            var stdData = _context.Student.Find(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Student std)
        {
            if (ModelState.IsValid)
            {
                _context.Update(std);
                _context.SaveChanges();
            }
            return View(std);
        }

        //Delete만들기
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            var stdData = _context.Student.FirstOrDefault(x => x.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmd(int? id)
        {
            var stdData = _context.Student.Find(id);

            if (stdData != null)
            {
                _context.Student.Remove(stdData); _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
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