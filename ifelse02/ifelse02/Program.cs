using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifelse02
{
    internal class Program
    {//관계연산자 AND = && , OR =||
        static void Main(string[] args)
        {
            int a;
            a = int.Parse(Console.ReadLine());

            if (a >= 90)
            {
                Console.WriteLine("A");

            }
            else if (a >= 80)
            {
                Console.WriteLine("B");
            }
            else if (a>=70)
            {
                Console.WriteLine("C");
            }
            else if (a>=60)
            {
                Console.WriteLine("D");
            }
            else
            {
                Console.WriteLine("F");
            }
            
        }
    }
}
