using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Pow(int x, int y)
        {
            int result = 1;
            for(int i =0; i<y; i++)
            {
                result *= x;
            }
            return result;
        }
        static void Main(string[] args)
        {
            /* int x = int.Parse(Console.ReadLine());
             int y = int.Parse(Console.ReadLine());
             int result= x;
             for(int i =1; i < y; i++) 
             {

                     result *= x;


             }
             Console.WriteLine(result);*/
            int x = 2;
            int y = 3;
            int result = Pow(x, y);
            Console.WriteLine(result);
        }
    }
}
