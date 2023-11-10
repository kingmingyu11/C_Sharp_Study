using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDirayFinal.Models;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace MyDirayFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiaryDbContext _context;

        public HomeController(DiaryDbContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var diarys = await _context.Diary.ToListAsync<Diary>();
        //    return View(diarys);
        //}
        public IActionResult Index()
        {
            var diarys = _context.Diary.ToList();
            return View(diarys);
        }

        //Create----------------------------
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Diary dr)
        {
            if(ModelState.IsValid)
            {
                _context.Diary.Add(dr);
                _context.SaveChanges();

            }
            return View(dr);
        }

        //Details-------------------------
        public IActionResult Details(int? id)
        {
            //if (no == null || _context.Diary == null)
            //{
            //    return NotFound();
            //}
            var stdData = _context.Diary.FirstOrDefault(x => x.No == id);
           
            //if (stdData == null)
            //{
            //    return NotFound();
            //}
            
            return View(stdData);
        }
        //Edit 만들기

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Diary == null)
            {
                return NotFound();
            }
            var stdData = _context.Diary.Find(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Diary std)
        {
            if (ModelState.IsValid)
            {
                _context.Update(std);
                _context.SaveChanges();
            }
            return View(std);
        }
        //Delete 만들기
        public IActionResult Delete(int id)
        {
            if (id == null || _context.Diary == null)
            {
                return NotFound();
            }
            var drData = _context.Diary.FirstOrDefault(x => x.No == id);
            if (drData == null)
            {
                return NotFound();
            }
            return View(drData);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmd(int? id)
        {
            var stdData = _context.Diary.Find(id);

            if (stdData != null)
            {
                _context.Diary.Remove(stdData); _context.SaveChanges();
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