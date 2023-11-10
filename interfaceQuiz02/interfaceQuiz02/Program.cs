using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceQuiz02
{
    interface IWeapon
    {
        string Attack();
    }
    interface IBow : IWeapon
    {

    }
    class Hero { 
    public string Name { get; set; }   
    }
    class Knight : Hero, IWeapon

    {
        public Knight(string name)
        {
            Name = name;
        }
        public string Attack()
        {
            return "활을 쏩니다.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight("아더");
            Console.WriteLine($"{knight.Name} 가 {knight.Attack()}");



        }
    }
}
