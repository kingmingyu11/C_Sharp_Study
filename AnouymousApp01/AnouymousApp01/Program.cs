using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnouymousApp01
{

    delegate int Calculate(int a, int b); //delegate는 동사 class는 명사

    internal class Program
    {

        static void Main(string[] args)
        {
            Calculate calc;

            calc = delegate (int a, int b)
            {
                return a + b; 
            };

            Console.WriteLine(calc(3, 4));
        }
    }
}
