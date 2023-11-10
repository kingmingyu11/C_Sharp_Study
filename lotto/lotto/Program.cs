using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
    internal class Program
    {
       
        static void Main(string[] args)
        {

            Random r = new Random();
            int Lotto;
            Console.Write("로또 번호");
            for(int i = 0; i < 7; i++)
            {
                Lotto = r.Next(1, 45);
                if(i== 6)
                {
                    Console.Write("\n 보너스번호:{0}", Lotto);
                }
                else
                {
                    Console.Write(Lotto + " ");
                }
            }
        }
    }
}
