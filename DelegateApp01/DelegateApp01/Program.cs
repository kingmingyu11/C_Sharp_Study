using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateApp01
{
    delegate int MyDelegate(int a, int b);
    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a+b;
        }
        public int Minus(int a, int b)
        {
            return a-b;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();

            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(5, 10));

            Callback = new MyDelegate(Calc.Minus);
            Console.WriteLine(Callback(5, 10));
        }
    }
}
