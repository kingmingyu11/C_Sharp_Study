using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* byte[] boolBytes = BitConverter.GetBytes(true);
             byte[] shortBytes = BitConverter.GetBytes((short)32000);
             byte[] intBytes = BitConverter.GetBytes(1652300);

             bool boolResult = BitConverter.ToBoolean(boolBytes, 0);
             short shortResult = BitConverter.ToInt16(shortBytes, 0);
             int intResult = BitConverter.ToInt32(intBytes, 0);

             Console.WriteLine(BitConverter.ToString(boolBytes));
             Console.WriteLine(BitConverter.ToString(shortBytes));
             Console.WriteLine(BitConverter.ToString(intBytes));

             Console.WriteLine(boolResult);
             Console.WriteLine(shortResult);
             Console.WriteLine(intResult);*/

            double a = double.Parse(Console.ReadLine());
            byte[] doubleBytes = BitConverter.GetBytes(a);
            Console.WriteLine(BitConverter.ToString(doubleBytes));

            double doubleResult = BitConverter.ToDouble(doubleBytes, 0);

            Console.WriteLine(doubleResult.ToString());

            double b = double.Parse(Console.ReadLine());
            byte[] doublebyte = BitConverter.GetBytes(b);
            Console.WriteLine(BitConverter.ToString(doublebyte));

            double doubler = BitConverter.ToDouble(doublebyte, 0);


        }
    }
}
