using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p._500quiz
{
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a , int b)
        {
            return a - b;
        }

    }
    internal class Program
    {

        
       
        static void Main(string[] args)
        {
            MyDelegate Callback;
            Calculator cal = new Calculator();
            Callback = new MyDelegate(cal.Plus);
                Console.WriteLine(Callback(3, 4));
            Callback = new MyDelegate(cal.Minus);
            Console.Write(Callback(7, 5));
        }
    }
}
