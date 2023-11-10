using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopApp
{
    
        class Calculator
        {
        public int SumLoop(int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                sum += i;


            }
            return sum;
        }
        }
       // static int  SumLoop(int start , int end) // c언어 스타일
       
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end= int.Parse(Console.ReadLine());

            Calculator cal= new Calculator();
            int result = cal.SumLoop(start,end);
           
            Console.WriteLine(result);

        }
    }
}
