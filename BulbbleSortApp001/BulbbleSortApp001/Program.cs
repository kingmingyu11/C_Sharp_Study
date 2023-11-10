using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbbleSortApp001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 99, 4, 75, 23, 5, 18, 19 };
            int temp;
            for(int i = 7-1; i>0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if (list[j] >= list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;

                    }
                    
                }
            }
            
            foreach(int i in list)

                Console.WriteLine(i);
            }
        }
    }

