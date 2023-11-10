using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 가로(width),세로(height)를입력받아 넓이구하기
            //변수선언
            int width;
            int height;
            //로직
            width = Int32.Parse(Console.ReadLine());
            height = Int32.Parse(Console.ReadLine());
            
            int result = width * height;
            Console.WriteLine(result);



        }
    }
}
