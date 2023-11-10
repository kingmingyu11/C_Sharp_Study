using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp009
{
    class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("도형을그리다");
        }
    }
    class Triangle : Shape
    {
       public override void Draw()
        {
            Console.WriteLine("삼각형을 그리다");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();
            shape.Draw();
            Triangle t1 = new Triangle();
            t1.Draw();
            Console.WriteLine();

            Shape t2 = new Triangle();
            t2.Draw();
        }
    }
}
