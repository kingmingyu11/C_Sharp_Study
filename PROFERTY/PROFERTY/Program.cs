using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROFERTY
{
    class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat nero = new Cat();
            nero.Name = "네로";
            nero.Age = 10;
            nero.Color = "검은색;";
           
        }
    }
}
