using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp04
{
   
    class Cat
    {
        
        
        //default 생성자
        public Cat() {
            this.name = "";
            this.color = "";
        }
        //인자가 있는 생성자
        public Cat(string _name,string _color)
        {
            this.name = _name;
            color = _color;

        }
        //멤버 변수 
        public string name;
        public string color;
        public void meow()
        {
            Console.WriteLine($"{name}:야옹");
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Cat kitty = new Cat("키티","하얀색");
            Console.WriteLine(kitty.name + kitty.color);

            Cat nero = new Cat("네로", "검은색");
            Console.WriteLine(nero.name + nero.color);

            
        }
    }
}
