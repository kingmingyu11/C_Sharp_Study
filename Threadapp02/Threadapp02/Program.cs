using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threadapp02
{
    internal class Program
    {
      
        static void Run()
        {
            for(int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Thread 프로그램 종료");
        }
        static void Main(string[] args)
        {
            //Thread 를 이용해서 1~10출력하는 프로그램작성
            Thread t = new Thread(new ThreadStart(Run));
            
            t.Name = "Thread";
            t.Start();
            t.Join();
            Console.WriteLine("메인 프로그램 종료");
        }
    }
}
