using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgmgmg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] a =Console.ReadLine().Split(' ');

            int x = int.Parse(a[0]);

            if (x >= 90)
                Console.WriteLine('A');
            else if (x >= 80)
                Console.WriteLine('B');
            else if (x >= 70)
                Console.WriteLine('C');
            else if (x >= 60)
                Console.WriteLine('D');
            else
                Console.WriteLine('F');

        }
    }
}
