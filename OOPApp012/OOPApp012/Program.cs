using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp012
{
    class Cat
    {
        public Cat()//생성자(디폴트) 
        {
            Console.WriteLine("객체의 생성자가 호출 되었습니다");
        }
        ~Cat() // 소멸자
        {
            Console.WriteLine("소멸자가 호출되었습니다.");
        }
    }
    class Rusianblue : Cat
    {
        public Rusianblue()
        {
            Console.WriteLine("Rusianblue 생성자가 호출되었습니다. ");
        }
        ~Rusianblue() {
            Console.WriteLine("Rusianblue 소멸자가 호출되었습니다");
                }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cat cat = new Cat();   
            Rusianblue rb= new Rusianblue();
        }
    }
}
