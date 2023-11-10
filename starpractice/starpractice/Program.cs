using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace starpractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
               
                for (int j = i; j <=n-2; j++)
                {
                    Console.Write(" ");
                }
                for(int j = 0; j < i*2+1 ; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
        }
    }
}

