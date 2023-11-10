using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00papp003
{
    class Cat
    {
        public string name;
        public string color;
        public int age;

        //생성자 
        public Cat() //default 생성자
        {
            //초기값
            this.name = "야옹이";
            this.age = 2;
            this.color = "누런색";
    }

        public void yaong()
        {
            Console.WriteLine(" 야옹~~");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat();
           // c.name = "네로";
            //c.color = "red";
           // c.age = 5;

            Console.WriteLine($"키티의 이름은 {c.name},키티의나이는{c.age},키티의 색깔은 {c.color},");
           

                
        }
    }
}
