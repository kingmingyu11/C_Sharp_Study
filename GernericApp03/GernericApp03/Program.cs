using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GernericApp03
{
    class Mylist<T> where T : struct // T는 값 형식 이어야 합니다.
    {

    }
    class Cat<T> where T: class // t는 참조형식이다.
    {

    }
    class Dog<T> where T : new() // T는 반드시 매개변수가 없는 생성자가 있어야한다.
    {
    } 

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
