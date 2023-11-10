using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threadQuiz
{
    internal class Program
    {
        static void plus()
        {
            int sum = 0;
            for (int i = 1; i <=100; i++)
            {
                
                sum += i;
                
               
            }
            Console.WriteLine(sum);
        Console.WriteLine("thread1종료");
        }
        static void alpha()
        {
            
            for(int i = 'A'; i <='Z'; i++)
            {
               
                Console.WriteLine((char)i);
            }
            Console.WriteLine("thread-2 종료");
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(plus));
            t1.Name = "Thread-1";
            t1.Start();
            t1.Join();
            Thread t2 = new Thread(new ThreadStart(alpha));
            t2.Name = "Thread-2";
            t2.Start();
            t2.Join();
            Console.Write("main 프로그램 종료");
        }
    }
}
