using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;


namespace CakeOrderSystem
{
    internal class Program

    {

        static void Main(string[] args)

        {

            int cnt = 0;

            //mainThread가 작업중

            Action sum = () =>

            {

                for (int i = 1; i <= 100; i++)

                {

                    cnt += i;

                }

                Console.WriteLine(cnt);

            };

            Task myTask1 = new Task(sum); // Action 대리자 구현부를 넣어주면 스레드처럼 동작

            myTask1.Start();

            myTask1.Wait();   // Join()



            Task myTask2 = Task.Run(() =>

            {

                for (int i = 'A'; i <= 'Z'; i++)

                {

                    Console.Write((char)i);

                }

            });

            myTask2.Wait();



            Console.WriteLine("메인 종료.");



        }

    }

}