using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stringapp002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ABC".ToLower());
            Console.WriteLine("abc".ToUpper());
            Console.WriteLine("Happy Friday!".Insert(5," Sunny"));
            Console.WriteLine("I Don't love you !".Remove(2,6));
            Console.WriteLine("           ABC       ".Trim());

        }
    }
}
