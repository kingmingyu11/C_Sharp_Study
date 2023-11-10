using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSyncApp01
{
    internal class Program
    {
        class Counter
        {
            public int count = 0;
            public void Increase()
            {
                lock ()
                {
                    count++;
                }

            }
        }
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Thread[] t1 = new Thread[10000];

            for(int i = 0; i<100; i++)
            {
                t1[i] = new Thread(counter.Increase); 
                t1[i].Start();

            }
           // Thread t2 = new Thread(counter.Increase);
            //Thread t3 = new Thread(counter.Increase);

            t1.Start();
            //t2.Start();
            //t3.Start();

            t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine(counter.count);

        }
    }
}
