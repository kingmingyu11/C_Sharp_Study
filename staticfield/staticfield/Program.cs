using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staticfield
{
    class Global
    {
        public static int Conut = 0;

    }
    class ClassA
    {
        public ClassA() {
            Global.Conut++;
        }
    }
    class ClassB
    {
        public ClassB(){
            Global.Conut++;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Global Count: {Global.Conut}");

             new ClassA();
             new ClassA();

            new ClassA();

            new ClassA();

            Console.WriteLine($"Global Count: {Global.Conut}");
            
        }
    }
}
