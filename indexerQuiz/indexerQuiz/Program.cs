using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace indexerQuiz
{
    class ArrayWrapper
    {
        private int[] arr;
        public ArrayWrapper()
        {
            arr = new int[5];
        }
        public int this[int index]
        {
            get { return arr[index]; }
            set
            {
                arr[index] = value;
            }
        }
            public void Print() { 
            foreach (int i in arr) {
                Console.WriteLine(i);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           ArrayWrapper array = new ArrayWrapper();
            for(int i = 0; i < 5; i++)
            {
                array[i] = i * 10;
            }
            array.Print();
        }
    }
}
