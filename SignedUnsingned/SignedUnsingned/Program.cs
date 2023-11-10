using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignedUnsingned
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte a = 255;
            sbyte b = (sbyte)a;//강제 형변환
            Console.WriteLine(b);

            uint c = uint.MaxValue; // 
            int d = int.MinValue;
            Console.Write($"c={c},d={d}" );
            float e = 3.141592f;
            double f = 3.141594;

        }
    }
}
