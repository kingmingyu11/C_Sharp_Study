using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiiiilz
{
    internal class Program
    {
        /* static int plus(int a, int b, int c, int d)
         {
             return a+b+c+d;

         }
         static void Main(string[] args)
         {
             Console.Clear();
             string[] input = Console.ReadLine().Split(' ');

             int a = int.Parse(input[0]);
             int b = int.Parse(input[1]);
             int c = int.Parse(input[2]);
             int d = int.Parse(input[3]);
             Console.Write(plus(a, b, c, d));
         }
     }*/

        static int plus(int a, int b, int c, int d)

        {

            return a + b + c + d;

        }

        static void Main(string[] args)

        {

            /*

             * 네 정수를 입력받아 합을 구하는 프로그램을 작성하려고 한다.

             * 입력

             * 1 에서 100000 이하의 네 정수가 입력으로 주어진다.

             * 출력

             * 네 정수의 합을 출력한다.

            */



            Console.Clear();

            string[] input = Console.ReadLine().Split(' ');



            int a = int.Parse(input[0]);

            int b = int.Parse(input[1]);

            int c = int.Parse(input[2]);

            int d = int.Parse(input[3]);



            Console.WriteLine(plus(a, b, c, d));

        }


    }
}
