﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp01
{
    class Tiger
    {
        private string name;
        private int age;
        public Tiger(string _name)
        {
            name = _name;
        }
        public void setAge(int _age)
        {
            this.age = _age;
        }
        public int getAge()
        {
            return age;
        }
        public string getName()
        {
            return name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tiger timon = new Tiger("티몬");
            timon.setAge(5);
            Console.WriteLine($"호랑이의 이름은 {timon.getName()}");
            Console.WriteLine($"티몬의 나이는 {timon.getAge()}");
        }
    }
}
