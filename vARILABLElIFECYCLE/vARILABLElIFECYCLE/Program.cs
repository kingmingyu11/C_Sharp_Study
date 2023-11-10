using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace vARILABLElIFECYCLE
{
    class SomeClass
    {
        public void SomeMethod() {
            int count = 0;
            SomeLocalFunction(1, 2);
            SomeLocalFunction(3, 4);

            void SomeLocalFunction(int a, int b)
            {
                //Do Some work
                Console.WriteLine($"count:{++count}");
            }
    }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SomeClass sc = new SomeClass();
            sc.SomeMethod();
           
        }
    }
}
