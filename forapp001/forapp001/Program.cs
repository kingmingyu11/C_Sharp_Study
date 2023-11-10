using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forapp001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1~100까지의합
            int sum = 0;
            int i = 0;
            
            for(i=0;i<=100;i++)
            {
                sum = sum + i;
            }
            Console.WriteLine(sum);
        }
    }
}
