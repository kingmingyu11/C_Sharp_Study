using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 최적의 몸무게 구하기 ..? 키 -110 이상적 몸무게 
            int tall;
            tall = Int32.Parse(Console.ReadLine());

            int result = tall - 110;
            Console.WriteLine($"최적의 몸무게 = {result}");
            
            
        }
    }
}
