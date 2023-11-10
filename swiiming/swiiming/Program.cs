using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swiiming
{
    internal class Program
    {

        static void Main(string[] args)
        {

           int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int[] arr = { 1, 2, 3 };
            int cnt = 0;
             for(int i = 0; i <n; i++)
               {
                 = rnd.next(1, 3);
                arr[i] = i;
                if (arr[i] !=i)
                    cnt++;

               }
               Console.WriteLine(cnt);
            






        }

    }
}

