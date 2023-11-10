using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateChain_easy
{


    internal class Program
    {
        delegate void AndongDaeWelcome(string abc);
        public static void AndongUnivercity(string abc)
        { 
        Console.WriteLine($"{abc}에 오신걸 환영합니다");
        }
        public static void Goodbye(string abc)
        {
            Console.WriteLine($"{abc}이제 곧 졸업입니다.");
        }
        public static void SeeYouLater(string abc) {
            Console.WriteLine($"{abc} 다음에 다시 올게요");
            }

        static void Main(string[] args)
        {
            AndongDaeWelcome ang = new AndongDaeWelcome(AndongUnivercity);

            ang += new AndongDaeWelcome(Goodbye);
            ang += new AndongDaeWelcome(SeeYouLater);
            ang("안동대");
        }
    }
}

