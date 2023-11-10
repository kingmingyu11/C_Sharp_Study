using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz2
{
    internal class Program
    {
        static void Main(string[] args, int sum)
        {
            int i;
            int sum;
            for(i = 1; i<=100; i++)
            {
                sum = sum + i;
                Console.WriteLine(sum);
            }
            
        }
    }
}
