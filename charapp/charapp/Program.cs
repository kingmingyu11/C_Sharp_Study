using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charapp
{
     class Program
    {
        static void Main(string[] args)
        {
            char a = '안';
            char b = '녕';
            string str = "안녕";

            Console.WriteLine($"{a}{b}");
            Console.WriteLine(str);
            string multi01 = "안녕\n하세요";
            Console.WriteLine(multi01);
          
                
        }
    }
}
