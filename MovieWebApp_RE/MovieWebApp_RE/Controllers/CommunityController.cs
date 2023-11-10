using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebApp_RE.Models;
using System.Diagnostics;

namespace MovieWebApp_RE.Controllers
{
    public class CommunityController : Controller
    {
        private readonly MovieDbContext _context;

        public CommunityController(MovieDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //----------------------커뮤니티-----------------------//
        [HttpGet]
        public IActionResult Community()
        {
            var com = _context.Community.ToList();
            return View(com);
        }

        public IActionResult CreateCommunity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCommunity(Community community)
        {
            if (ModelState.IsValid)
            {
                _context.Community.Add(community);
                _context.SaveChanges();
                return RedirectToAction("Community");
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    // 오류 메시지 로깅
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(community);
        }
        //디테일


        public async Task<IActionResult> CommunityDetails(int? id)
        {
            if (id == null || _context.Community == null)
            {
                return NotFound();
            }

            var stdData = await _context.Community.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }


        // 수정
        public async Task<IActionResult> CommunityEdit(int? id)
        {
            if (id == null || _context.Community == null)
            {
                return NotFound();
            }

            var stdData = await _context.Community.FindAsync(id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost]
        public async Task<IActionResult> CommunityEdit(int? id, Community std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //_context.Student.Update(std);
                _context.Update(std);
                await _context.SaveChangesAsync();
                return RedirectToAction("Community");

            }
            return View(std);

        }

        //게시판 삭제


        public async Task<IActionResult> CommunityDelete(int? id)
        {
            if (id == null || _context.Community == null)
            {
                return NotFound();
            }
            var stdData = await _context.Community.FirstOrDefaultAsync((x => x.Id == id));

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await _context.Community.FindAsync(id);
            if (stdData != null)
            {
                _context.Community.Remove(stdData);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Community");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
