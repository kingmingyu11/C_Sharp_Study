using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quiz13
{
    abstract class Shape
    {
        public void draw()
        {
        }
    }
    class Triangle : Shape
    {
        public Triangle()
        {
            Console.WriteLine("삼각형을 그리다. ");
        }
    }
    class Rectangle : Shape
    {
        public Rectangle()
        {
            Console.WriteLine("사각형을 그리다. ");
        }
    }
    class Circle : Shape
    {
        public Circle()
        {
            Console.WriteLine("원을 그리다. ");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            triangle.draw();

            Rectangle rectangle = new Rectangle();
            rectangle.draw();
    
            Circle circle = new Circle();
            circle.draw();
        }
    }
}
