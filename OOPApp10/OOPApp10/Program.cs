using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp10
{
    internal class Program
    {
        abstract class Shape
        {
            public abstract void Draw();
            
        }
        class Triangle : Shape
        {
            public override void Draw()
            {
                Console.WriteLine("삼각형을 그리다");
            }
        }
        static void Main(string[] args)
        {
            //실세계
            Shape s = new Triangle();
            s.Draw();
            Triangle t = new Triangle();
            t.Draw();
        }
    }
}
