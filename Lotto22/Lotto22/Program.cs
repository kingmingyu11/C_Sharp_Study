using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int Lotto;
            Console.Write("로또번호 : ");
            for(int i = 0;i<7; i++)
            {
                Lotto = r.Next(1, 46);
                if( i == 6)
                {
                    Console.WriteLine("\n보너스번호: {0}",Lotto);
                }
                else
                {
                    Console.Write(Lotto+ " ");
                }
            }
        }
    }
}
