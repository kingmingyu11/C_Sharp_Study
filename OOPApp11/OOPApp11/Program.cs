using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp11
{
   
    abstract class Animal

    {
        public abstract string Eat();
        
    }
    class Cat : Animal
    {
        public override string Eat()
        {
            return "먹다";
        }
    }
    class Maincun : Cat { }



    internal class Program
    {
        static void Main(string[] args)
        {
            Maincun mg = new Maincun();
            Console.WriteLine(mg.Eat());
        }
    }
}
