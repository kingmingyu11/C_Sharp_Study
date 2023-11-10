using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPapp006
{
    class Car
    {
        public virtual void Run()
        {
            Console.WriteLine("차가 달리다");
        }
    }
    class Supercar : Car
    {
        public override void Run()
        {
            Console.WriteLine("supercar 가 달리다");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Run();
            Supercar superCar = new Supercar();
            superCar.Run();
        }
    }
}
