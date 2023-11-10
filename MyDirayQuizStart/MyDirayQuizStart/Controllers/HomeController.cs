using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDirayQuizStart.Models;
using System.Diagnostics;

namespace MyDirayQuizStart.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiaryDbContext _diaryDb;
        public HomeController(DiaryDbContext diartDb)
        {
            _diaryDb=diartDb;
        }

        public IActionResult Index()
        {
            var diaryData = _diaryDb.Diary.ToList();
            return View(diaryData);
        }
        [HttpPost]
        public IActionResult Result(Diary dr)
        {
            return View(dr);
        }
    

        public IActionResult Privacy()
        {
            return View();
        }
 
        public IActionResult Create()
        {
            return View();
        }

        // POST: 삽입기능
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create([Bind("No,Title,Content,Date")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                _diaryDb.Add(diary);
                await _diaryDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diary);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}