using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arraytest001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1부터 10 까지 들어있는 정수형 배열
            int[] arr = new int[10];
            
            for(int i =0;  i <arr.Length; i++)
            {
                arr[i] = i+1; // 배열은 선형적 메모리
                Console.WriteLine(arr[i]);

            }
         
        }
    }
}
