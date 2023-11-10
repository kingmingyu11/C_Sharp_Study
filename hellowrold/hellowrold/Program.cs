using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hellowrold
{
    internal class Program
    {
        static double Add(int a, int b)
        {

            return a + b;
        }

        static void Main(string[] args)
        {

            int value1 = 100;
            int value2 = 200;
           double result = Add(value1, value2);

            Console.WriteLine(result);
            Console.WriteLine(Add(value1,value2));




        }

    } }

