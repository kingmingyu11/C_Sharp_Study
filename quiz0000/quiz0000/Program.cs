using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz0000
{
    class Myclass {
        public int CharCounter(string arr, char ch)
        {
            int cnt = 0;
            //코딩
            for(int i =0 ; i < arr.Length;i++)
            {
                if (arr[i] == ch)
                {
                    cnt++;
                }
            }
            return cnt;


        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("문자열입력 :");
            string str = Console.ReadLine();

            Console.Write("문자 입력 :");
            string str2 = Console.ReadLine();

            //char c = str2[[0];
          char c = str2.ElementAt(0);

            Myclass myclass = new Myclass();
            int result = myclass.CharCounter(str, c);
            Console.WriteLine("결과: " + result);
        }
    }
}
