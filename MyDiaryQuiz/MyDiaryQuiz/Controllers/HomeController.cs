using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDiaryQuiz.Models;
using System.Diagnostics;

namespace MyDiaryQuiz.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DiaryDbContext _diaryDb;
        public HomeController(DiaryDbContext diaryDb)
        {
            _diaryDb = diaryDb;
        }
        [HttpPost]
        public IActionResult Index()
        {
            var diarydata = _diaryDb.Diary.ToList();
            return View(diarydata);
        }
        ////Get 화면
        //public IActionResult Create()
        //{
        //    return View();
        //}
  

        //[HttpPost]
        ////public IActionResult Result(Diary dr)
        ////{
        ////    return View(dr);
        ////}
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("No,DateTime,Title,Content")] Diary student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _diaryDb.Add(student);
        //        await _diaryDb.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}

        ////삭제
        //[HttpPost]
        //public async Task<IActionResult> DeleteSelected(List<int> selectedStudents)
        //{
        //    var studentsToDelete = _diaryDb.Diary.Where(s => selectedStudents.Contains(s.No)).ToList();

        //    _diaryDb.Diary.RemoveRange(studentsToDelete);
        //    await _diaryDb.SaveChangesAsync();

        //    return RedirectToAction("Index");

        //}
        //public IActionResult Update(Diary dr)
        //{
        //    return View();
        //}

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