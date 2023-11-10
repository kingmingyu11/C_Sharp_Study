using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopapp004
{
    class Calculator
    {
        //정수 두개를 합산하는 plus 메소드
        public int Plus(int x, int y)
        {
            return x + y;
        }
        // 정수 네개를 합산하는 plus 메소드
        public int Plus(int x, int y, int z, int w)
        {
            return x + y + z + w;
        }
        //실수 두개를 합산하는 플러스메소드
        public double Plus(double x, double y)
        {
            return x + y;
        }
    }

        internal class Program
        {
            static void Main(string[] args)
            {
              Calculator calulator = new Calculator();
            Console.WriteLine(calulator.Plus(100, 200));
            Console.WriteLine(calulator.Plus(100, 200,300,400));

            Console.WriteLine(calulator.Plus(100, 200.5));

        }
    }
    }

