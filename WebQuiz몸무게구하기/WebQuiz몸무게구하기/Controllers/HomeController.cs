using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebQuiz몸무게구하기.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult index(double height,double weight,string sex)
        {
            double ManAvgWeight = (height / 100) * (height / 100) * 22;
            double WomanAvgWeight = (height / 100) * (height / 100) * 21;
            if (sex== "남")
            {
                
                if((weight/ManAvgWeight) *100 >=160)
                {
                    ViewBag.Result = "고도비만";
                }
                else if((weight / ManAvgWeight) * 100 >=130)
                {
                    ViewBag.Result = "중정도비만";
                }
                else if ((weight / ManAvgWeight) * 100 >=120)
                {
                    ViewBag.Result = "경도비만";
                }
                else if ((weight / ManAvgWeight) * 100 >=110)
                {
                    ViewBag.Result = "과체중";
                }
                else if ((weight / ManAvgWeight) * 100 >=90)
                {
                    ViewBag.Result = "정상체중";
                }
                else 
                {
                    ViewBag.Result = "저체중";
                }
              
            }

            if (sex == "여")
            {

                if ((weight /WomanAvgWeight) * 100 >= 160)
                {
                    ViewBag.Result = "고도비만";
                }
                else if ((WomanAvgWeight / weight) * 100 >=130)
                {
                    ViewBag.Result = "중정도비만";
                }
                else if ((weight / WomanAvgWeight) * 100 >=120)
                {
                    ViewBag.Result = "경도비만";
                }
                else if ((weight / WomanAvgWeight) * 100 >=110)
                {
                    ViewBag.Result = "과체중";
                }
                else if ((weight / WomanAvgWeight) * 100 >=90)
                {
                    ViewBag.Result = "정상체중";
                }
                else
                {
                    ViewBag.Result = "저체중";
                }

            }


            return View();
        }
    }
}
