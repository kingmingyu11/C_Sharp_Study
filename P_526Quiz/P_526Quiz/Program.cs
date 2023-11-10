using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_526Quiz
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            /*int[] array = { 11, 22, 33, 44, 55 };

             foreach(int a in array)
             {
                 Action action = new Action
                 (
                     delegate ()
                     {
                         Console.WriteLine(a *a);
                     }
                 );
                 action.Invoke();*/ //강제 호출


            int[] array = { 11, 22, 33, 44, 55 };
            foreach (int a in array) {



                Action<int> action = (x) =>
                {
                    int result = x * x;
                    Console.WriteLine(result);
                };

                action(a);
            }
            }
        }
    }

