using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 1;
            for(int i= 0;i<3;i++)
            {
                for (int j = 2; j > i; j--)
                {
                    Console.Write(" ");
                }
                for(int k =0; k< num; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                num = num + 2;


            }
           /* num = 3;
            int num2 = 1;
            for(int i = 0; i < 2; i++)
            {
                for(int j =0; j <num2;j++)
                {
                    Console.Write(" ");
                }
                for(int k = 0; k<num; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                num -= 2;
                num2 += 1;
            }
           */

        }
    }
}


