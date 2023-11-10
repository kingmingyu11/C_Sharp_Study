using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp
{
    abstract class Animal {
        public virtual void Eat()
        {

        }
    }
    class dog : Animal
    {

    }
    class bulldog : dog { }


    internal class Program
    {
        static void Main(string[] args)
        {
            bulldog bd = new bulldog(); 
            bd.Eat();
        }
    }
}
