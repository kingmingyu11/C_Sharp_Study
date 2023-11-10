using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace calculator01
{
    //사칙연산을 하는계산기 만들기
     class Dog
    {
        private string name;
        //메소드
       public string Name{ get; set;
        }
        public Dog(string name)
        {
            Name = name;
            
        }

        public string Eat() {
            return "먹습니다";
        }
        public string Play()
        {
            return "뛰어놀다";
        }
       
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Dog tom = new Dog("톰");
            Console.Write($"{tom.Name}이 음식을 {tom.Eat()}");
            Console.Write($"{tom.Name}이  {tom.Play()}");


        }
    }
}
