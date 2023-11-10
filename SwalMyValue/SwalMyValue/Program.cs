using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwalMyValue
{
    internal class Program
    {
        static void swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
            Console.WriteLine($"{a} {b}");
        }


        static void Main(string[] args)
        {
            int x= 3;
            int y = 4;
            Console.WriteLine($"{x} {y}");

            swap(ref x,ref  y);
            Console.WriteLine($"{x} {y}");



        }
    }
}
