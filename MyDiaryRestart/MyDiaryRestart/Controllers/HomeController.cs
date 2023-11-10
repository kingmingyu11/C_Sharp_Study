using Microsoft.AspNetCore.Mvc;
using MyDiaryRestart.Models;
using System.Diagnostics;

namespace MyDiaryRestart.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiaryDbContext _diaryDb;
        public HomeController(DiaryDbContext diartDb)
        {
            _diaryDb = diartDb;
        }

        public IActionResult Index()
        {
            var diaryData = _diaryDb.Diary.ToList();
            return View(diaryData);
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Write()
        {
            return View();
        }
        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Write([Bind("No,Title,Content,Date")] Diary diary)

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