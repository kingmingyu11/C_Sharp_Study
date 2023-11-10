using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizzzzzzzzzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] BigAlpha = new char[26];
            char ba = 'Z';
            for (int i = 0; i < BigAlpha.Length; i++)
            {
                BigAlpha[i] = ba--;

            }
            for (int j = 0; j < BigAlpha.Length; j++)
            {
                Console.Write(BigAlpha[j] + " ");
            }
            Console.WriteLine();
            char[] smallAlpha = new char[26];
            char ca = 'z';
            for (int i = 0; i < BigAlpha.Length; i++)
            {
                BigAlpha[i] = ca--;

            }
            for (int j = 0; j < BigAlpha.Length; j++)
            {
                Console.Write(BigAlpha[j] + " ");
            }


        }
    }
}
