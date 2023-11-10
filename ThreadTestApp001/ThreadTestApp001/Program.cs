using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTestApp001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //main 동작중(보이진않지만)

            Action someAction = () =>
            {
                //코딩
                //1. 1~100까지 더하는것.
                int i;
                int sum = 0;
                for(i = 1; i<=100; i++)
                {
                    sum += i;
                }
                Console.WriteLine(sum);
               
            };
            Action someAction2 = () =>
            {
                int i;
                //2.A~Z 까지 출력.
                for (i = 'A'; i <= 'Z'; i++)
                {
                    Console.WriteLine((char)i);
                }
                
            };
            Task myTask1 = new Task(someAction);//메소드 //Action대리자 구현부분 //taks를 가장 쉽게 사용하려면..
            myTask1.Start();
            myTask1.Wait(); //Join() 


            Task myTask2 = new Task(someAction2);
            myTask2.Start();
            myTask2.Wait(); //join()


            Console.WriteLine("main 종료");
        
        }
    }
}
