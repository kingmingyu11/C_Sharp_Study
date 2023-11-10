using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopapp001
{
        class Cat
    {
        //필드 ,멤버변수
        public string Name;
        public string Color;
    }
     class Program
    {
        static void Main(string[] args)
        {
            Cat tom = new Cat();
            tom.Name = "톰";
            Console.WriteLine(tom.Name);
            Cat kitty = new Cat();
            kitty.Color = "하얀색";
            kitty.Name = "키티";
            Console.WriteLine(kitty.Name + " " + kitty.Color);
        }
    }
}
