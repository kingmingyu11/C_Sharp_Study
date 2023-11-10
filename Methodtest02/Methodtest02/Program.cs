using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodtest02
{
    internal class Program
    {
        class MyApp
        {
            public  int Min(int a, int b)
            {
                if (a < b)
                    return a;
                else
                  return b;

            }
            public int Max(int a, int b)
            {
                if(a>b) return a; else
                    return b;

            }
                
            
        }
        static void Main(string[] args)
        {
            int[] score = new int[3];
            for(int i = 0; i <2; i++)
            {
                score[i] = int.Parse(Console.ReadLine());
            }
            MyApp app = new MyApp();

            Console.WriteLine(app.Min(score[0], score[1]));
            Console.WriteLine(app.Max(score[0], score[1]));
        }
    }
}
