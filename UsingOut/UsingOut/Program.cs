using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingOut
{
   
    internal class Program
    {
       

        
        static void Main(string[] args)
        {
            double mean = 0;
            double q = 1;
            double w = 2;
            double e = 3;
            double r = 4;
            double t = 5;

            Mean(ref q, ref w, ref e,ref r,ref  t,ref mean);
            
            Console.WriteLine("평균 :  {0}", mean);

        }
        public  static void Mean(
            ref double a, ref double  b, ref double c,
            ref double d, ref double e ,ref double mean)
        {
            mean = (a + b + c + d + e) / 5;
        }
    }
}
