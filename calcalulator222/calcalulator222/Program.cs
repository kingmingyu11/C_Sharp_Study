using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace calcalulator222
{
    class Calculator
    {
        public int kor
        {
            get; set;
        }
        public int eng
        {
            get; set;
        }
        public int math { get; set; }
        public int excuteTotalScore() //동사형을 써라.
        {
            return kor + eng + math;
        }
        public int excuteAvg()
        {
            return (kor + eng + math) / 3;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine("국어 : ");

           calculator.kor = int.Parse(Console.ReadLine());
            Console.WriteLine("영어 : ");
            calculator. eng= int.Parse(Console.ReadLine());
            Console.WriteLine("수학 : ");
            calculator.math = int.Parse(Console.ReadLine());
            Console.WriteLine($"총점 {calculator.excuteTotalScore()}");
            Console.WriteLine($"평균;{calculator.excuteAvg()}");
        }
    }
}
