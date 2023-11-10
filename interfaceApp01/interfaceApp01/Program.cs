using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfaceApp01
{
    interface Wing 
    {
         void Fly();
    } 

    class Horse
    {

    }
    class Angel : Wing
    {
        public void Fly()
        {
            Console.WriteLine("천사 날다");
        }
    }

    class Unicon : Horse, Wing  //자바,c#에서는 다중이안됨 c++은 다중상속이 됨
    {
        public void Fly()
        {
            Console.WriteLine("유니콘이 날다");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Angel angel = new Angel();  
            angel.Fly();
            Unicon unicon = new Unicon();
            unicon.Fly();
        }
    }
}
