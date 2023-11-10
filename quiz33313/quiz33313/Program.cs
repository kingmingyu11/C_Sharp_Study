using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz33313
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year;
             year = int.Parse(Console.ReadLine());
            int age = 2023 - year+1;
            Console.WriteLine(age);
            Console.WriteLine($"만({age-1})세");

        }
    }
}
