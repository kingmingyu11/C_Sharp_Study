using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llaamdda
{
    internal class Program
    {
        delegate int Calulate(int a, int b);
        static void Main(string[] args)
        {
            Calulate calc = (a, b) => a + b;
            Console.WriteLine(calc(3, 4));
        }
    }
}
