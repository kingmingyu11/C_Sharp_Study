using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInterpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("문자열을 입력하세요:");
            string input = Console.ReadLine(); char[] arr= input.ToCharArray();
            int cnt1 = 0, cnt2 = 0, cnt3 = 0, cnt4 = 0;
            for(int i = 0 ; i < arr.Length; i++)
            {
                if (arr[i] >= 'A' && arr[i] <= 'Z')
                    cnt1++;
            }
            Console.WriteLine(cnt1);
        }
    }
}
