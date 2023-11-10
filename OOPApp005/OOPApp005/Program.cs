using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp005
{
    class Program
    {
       
        class Car
        {
            public string name;
            protected int speed;
            private string brand;
            public void Run()
            {
                Console.WriteLine("차가달리다");
            }
        }
        class SuperCar : Car
        {
         public SuperCar()
            {
                this.speed = 100;
                
            }   
        }
        static void Main(string[] args)
        {
            SuperCar sc = new SuperCar();
            sc.Run();
            sc.name = "자동차";
        }
    }
}
