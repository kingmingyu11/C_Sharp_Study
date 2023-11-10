using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QUIZcat
{
    internal class Program
    {
        class Cat{
            private string name;
            private int age;
            private string color;

            public void setName(string _name)
            {
                name = _name;
            }
            public void setColor(string _color)
            {
                color = _color;
            }
            public void setAge(int _age)
            {
                age = _age;
            }
            public string getName()
            {
                return name;
            }
            public int getAge()
            {
                return age;
            }
            public string getColor()
            {
                return color;
            }
        
        
        
        }

        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.setName("네로");
            cat.setColor("black");
            cat.setAge(10);
            Console.WriteLine($"이름: {cat.getName()} 색깔: {cat.getColor()}, 나이: {cat.getAge()}");
            



        }
    }
}
