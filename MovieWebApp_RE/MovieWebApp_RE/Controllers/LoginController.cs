using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebApp_RE.Models;

namespace MovieWebApp_RE.Controllers
{
    public class LoginController : Controller
    {
        private readonly MovieDbContext _context;

        public LoginController(MovieDbContext context)
        {
            _context = context;
        }
        public IActionResult Login(User user)
        {
          //초기 렌더링 시 오류 메시지를 초기화합니다.
               ModelState.Clear();

               var dbUser = _context.User.FirstOrDefault(u => u.Address == user.Address && u.Pw == user.Pw);

            //if (dbUser != null && user.Address == "admin")
            //{
            //    // 관리자 로그인 성공
            //    return RedirectToAction("Index", "Home");
            //}
            //else if (dbUser != null && user.Address != "admin")
            //{
            //    // 사용자 로그인 성공
            //    return RedirectToAction("User", "User");
            //}
            //else
            //{
            //    // 로그인 실패
            //    ModelState.AddModelError("", "아이디 비밀번호를 정확히 입력해주세요.");

            //    return View("Login", "Login");
            //}
            return View();


            }
            public IActionResult Join()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Join([Bind("Address,Pw,Name,Gender,Day,Hp")] User users)
            {
                if (ModelState.IsValid)
                {
                    await _context.AddAsync(users);
                    await _context.SaveChangesAsync();
                  return RedirectToAction("Login", "Login");
                }

                return View(users);
            }
        }
    }

