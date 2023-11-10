using System;

namespace whiletest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
           
            for(i = 100; i > 0; i--)
            {
                if (i % 13 == 0)
                    Console.WriteLine(i);
            }

        }
    }
}
