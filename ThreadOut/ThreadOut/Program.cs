using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadOut
{
    internal class Program
    {
        static void threadFunc()
        {
            Console.WriteLine("5초후 종료");
            Thread.Sleep(10000);
            Console.WriteLine("스레드 종료");
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(threadFunc));
            t.IsBackground = true;
            t.Start();
            t.Join();
            Console.Write("메인스레드 종료");
        }
    }
}
