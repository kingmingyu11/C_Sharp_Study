using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 123;
            object b = (object)a; //boxing  힙공간에 123을 넣었다.
            int c = (int)b; //unboxing 

            Console.WriteLine(c);
            Console.WriteLine(a);   
            Console.WriteLine(b);
            

            double x = 3.141592;
            object y = x;
            double z = (double)y;
        }
    }
}
