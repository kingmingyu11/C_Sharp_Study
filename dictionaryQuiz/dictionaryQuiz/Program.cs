using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionaryQuiz
{
    internal class Program
    {
        static string CheckLogin(Dictionary<string, string> userInfo, string id, string pwd)
        {
            if (userInfo["userid"] == id && userInfo["userpassword"] == pwd)
            {
                return "로그인에 성공";
            }
            else
            {
                return "로그인에 실패";


            }
        }


        static void Main(string[] args)
        {
            Dictionary<string, string> userInfo = new Dictionary<string, string>
        {
            {"userid","mingyu" },
            {"userpassword","1234" }

        };
            string id, pwd;

            Console.WriteLine("아이디");
            id = Console.ReadLine();

            Console.WriteLine("비밀번호");
            pwd = Console.ReadLine();

            Console.WriteLine(CheckLogin(userInfo, id, pwd));

        }
    }
}
