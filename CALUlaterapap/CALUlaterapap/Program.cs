using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALUlaterapap
{ 
    class Calculator
    {
        //멤버변수
        //생성자
        //멤버메소드
        public int plus(int a, int b)
        {
            return a + b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //real wolrd
            Calculator calculator = new Calculator();
            int result = calculator.plus(100, 200);
            Console.WriteLine(result);

        }
    }
}
