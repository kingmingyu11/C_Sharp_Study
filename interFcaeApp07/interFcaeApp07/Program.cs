using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interFcaeApp07
{

    interface IRunnable
    {
        void Run();
    }
    interface IFlyable
    {
        void Fly();
    }
    class FlyingCar : IRunnable, IFlyable
    {
        public void Run()
        {
            Console.WriteLine(" RUN RUN !!");
        }
        public void Fly()
        {
            Console.WriteLine("Fly Fly");
        }

        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FlyingCar flyingcar = new FlyingCar();
            flyingcar.Run();
            flyingcar.Fly();

            IRunnable runnable = flyingcar as IRunnable;
            runnable.Run();
            IFlyable flyable = flyingcar as IFlyable;
            flyable.Fly();
        }
    }
}
