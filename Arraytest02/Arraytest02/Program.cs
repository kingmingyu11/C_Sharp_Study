using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arraytest02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];
                int cnt = 1;
            for(int i = 0; i <5; i++)
            {
                arr[i] = cnt;
                cnt += 2;
                Console.WriteLine(arr[i]);

            }
            
        }
    }
}
