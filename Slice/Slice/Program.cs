using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slice
{
    internal class Program
    {
          static void PrintArray(System.Array array)
            {
                foreach(var e in array)
                    Console.Write(e);
                Console.WriteLine();
            }
        static void Main(string[] args)
        {

            char[] array = new char [ 'Z' - 'A' + 1 ];// Z(90) - A(65)+! 

            for (int i = 0; i < array.Length; i++) 
                array[i] = (char)('A' + i);
            PrintArray(array[..]);
        }
    }
}
