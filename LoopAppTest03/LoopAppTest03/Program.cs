using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopAppTest03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n;
            
            do
            {
                Console.Write("정수를 입력하세요 :");
                n = int.Parse(Console.ReadLine());
                switch (n)
                {
                     case 1:
                        Console.WriteLine("1을 입력하였습니다");
                        break;
                     case 2:
                        Console.WriteLine("2를 입력하였습니다");
                        break;
                     default: Console.WriteLine("1과 2이외의 값을 입력했습니다");
                        break;
            }
                if (n == 100)
                {
                    Console.WriteLine("종료합니다");

                    break;
                }
            } while (true);
           
        }
    }
}
