using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DFDF
{
    internal class Program
    {
        // Fn = fn-1 + fn-2
        static int fibonachi(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
           
            return fibonachi(n-1) + fibonachi(n - 2);

        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int result = fibonachi(n);
            Console.WriteLine(result);
             
            
        }
    }
}
                

            
        
    

           
            
            
        
                
           
        
        
 
