using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifelse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("숫자 입력:");

            int number;
            number = int.Parse(Console.ReadLine());

            if (number > 0)
            {
                Console.WriteLine("양수입니다.");
            }
            else if (number < 0)
            {
                Console.WriteLine("음수입니다.");

            }
            else { Console.WriteLine("0입니다"); }

            if (number %2 == 0)
            {
                Console.WriteLine("짝수입니다");
            }
            else
            {
                Console.WriteLine("홀수입니다");
            }
        
        
        
        }


    }
}
