using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp0151
{

    class Myclass {
        public int MyField1;
        public int MyField2;
        public Myclass DeepCopy() { 
        
        
        Myclass newCopy = new Myclass();
            newCopy.MyField1 = MyField1;
            newCopy.MyField2 = MyField2;
            return newCopy;

        }


    }


    internal class Program
    {
        
        static void Main(string[] args)
        {
            Myclass source = new Myclass();
            source.MyField1 = 10;
            source.MyField2 = 20;

            //Myclass target = source;
            Myclass target = source.DeepCopy();
            target.MyField2 = 30;
            Console.WriteLine(source.MyField1 + " " + source.MyField2);
            Console.WriteLine(target.MyField1 + " " + target.MyField2);




        }
    }
}
