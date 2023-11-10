using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp014
{

    abstract class Shape
    {
        public abstract void Draw()
        {

        }
    }
    class Triangle : Shape
    {

    }
    class Rectangle : Shape
    {
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            //Shape s = new Shape();
            Triangle t = new Triangle();
            Rectangle r = new Rectangle();

        }
    }
}
}
