using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedClassApp
{
    internal class Program
    {
        class OuterClass
        {
            private int OuterNumber;
            class Innerclass
            {
                public void DoSometing() {
                    OuterClass outer = new OuterClass();
                    outer.OuterNumber = 100;
                }
            
              
               
                
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
