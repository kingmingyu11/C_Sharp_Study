using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame
{
    interface IWeapon
    {
        string Attack();
    }
    interface IBow : IWeapon
    {

    }
    class Hero
    {
        public string Name { get; set; }
    }
    class Knight : Hero, IWeapon

    {
     
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Common.Story story = new Common.Story();
            story.InitStory();
            Knight knight = new Knight("아더");
            Console.WriteLine($"{knight.Name} 가 {knight.Attack()}");



        }
    }
}