using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 123;
            string b = a.ToString();
            Console.WriteLine(b);
            float c = 3.14f;
            string d = c.ToString();
            Console.WriteLine(d);

            string e = "123455";
            int f = Convert.ToInt32(e);

            string g = "1.2345";
                
            float h= float.Parse(g)
                ;

    Console.WriteLine(h);
        }
    }
}
