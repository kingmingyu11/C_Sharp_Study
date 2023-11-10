using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AraayApp05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //연속된 메모리 공간에 알파벳 대문자 26자를 넣어보세요.
            char[] arr = new char[26]; // arr[0]~ arr[n-1]
            //Console.WriteLine(arr.Length);
            char ch = (char)65;
            for(int i=0; i< arr.Length; i++)
            {
                arr[i] = ch++;
            }
            for(int j= 0; j<arr.Length; j++)
            {
                Console.Write(arr[j]+ " ");
            }
            
        }
    }
}
