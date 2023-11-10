using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadApp01
{
 
    internal class Program
    {
        static void DoSomeThing()
        {
            for( int i=1; i < 1000; i++)
            {

            }
            Console.WriteLine($"DoSomeThing Thread ID:{Thread.CurrentThread.ManagedThreadId}");
        }
        static void Print()
        {
            Console.WriteLine($"Print Thread ID:{Thread.CurrentThread.ManagedThreadId}");
        }
        static void Main(string[] args)
        {
            ////Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId}");
            ////Print();
            ////Thread t = new Thread(new ThreadStart(DoSomeThing));   
            ////t.Start();

        }
    }
}
