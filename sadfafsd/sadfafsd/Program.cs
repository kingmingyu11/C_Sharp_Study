using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sadfafsd
{
    internal class Program
    {
        static int Plus(int a, int b)
        {
            return a + b;   
        }
        static double Divide(int a, int b)
        {
            return a / (double)b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Plus(100, 200));
            Console.WriteLine(Divide(300, 170));
            
        }
    }
}
