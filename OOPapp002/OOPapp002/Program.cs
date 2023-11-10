using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OOPapp002
{
    class Dog
    {
        public String Name;
       public int age;
        public string color;
        public void Bark()
        {
            Console.WriteLine("멍멍");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog nero = new Dog();
            nero.color = "검은색";
            nero.Name = "네로";
            nero.Bark();
            Console.WriteLine(nero.Name + " " + nero.color);
        }
    }
}
