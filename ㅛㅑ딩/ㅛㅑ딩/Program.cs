using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ㅛㅑ딩
{
    class MyEnumerator
    {
        private int[] number = { 1, 2, 3, 4 };

        public IEnumerator GetEnumerator()
        {
            yield return number[0];
            yield return number[1];
            yield return number[2];
            yield break;

            yield return number[3];
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                var obj = new MyEnumerator();
                foreach(var item in obj) 
                    Console.WriteLine(item);
            }
        }
    }
}