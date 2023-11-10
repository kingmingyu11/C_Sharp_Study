using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N : ");
            Console.Read();
            for (int i = 0; i < 1; i++)
            {
                if (i <= 90)
                {
                    Console.WriteLine("A학점 입니다.");
                }

                else
                {

                    Console.WriteLine("B학점 입니다. ");
                }
            }
        }
    }
}
