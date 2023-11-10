using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceExam01
{
    
    interface IWeapon
    {
        void attack();
    }
    interface IBow : IWeapon {
        
    }

    class Hero
    {
       public string Name { get; set; } // 생성지
    }
    class Knight : Hero, IBow
    {
        public Knight(string name)
        {
            Name = name;
        }
        public void attack()
        {
            Console.WriteLine(Name+"가 활을 쏩니다");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Knight knight = new Knight("아더");
          
            knight.attack();
        }
    }
}
