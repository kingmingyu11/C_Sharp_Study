using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace FuncTest
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            /*  Func<int> func1 = () => 10;
              Console.WriteLine($"func1() : {func1()}");

              Func<double,double> func2 = (x) => x *3.14;
              Console.WriteLine(func2(100));

              Func<int, int, int> func3 = (x, y) => x + y;
              Console.WriteLine(func3(100, 200));

              Console.WriteLine();

              Action act1 = () => Console.WriteLine("Action()");
              act1();

              int result = 0;
              Action<int> act2 = (x) => result = x * x;

              act2(3);
              Console.WriteLine(result);*/
            //for(int i=0; i<=5; i++)

            //{

            //    GetNumber();

            //    OutNumber();

            //    GetTime();

            //    OutTime();

            //    Thread.Sleep(1000);

            //}

            await Task.Run(() =>

            {

                for (int i = 0; i <= 5; i++)

                {

                    GetNumber();

                    this.Invoke(new Action(() =>

                    {

                        OutNumber();

                    }));

                    GetTime();

                    this.Invoke(new Action(() =>

                    {

                        OutTime();

                    }));

                    Thread.Sleep(1000);

                }
            }
    }
}
