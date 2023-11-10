using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MeThod1
{
    internal class Program

    {
       
        static void Main(string[] args)
        {
            Random r = new Random();
            int Lotto;
            for(int i = 0; i < 6; i++)
            {
                Lotto = r.Next(1, 46);
                if (i == 6)
                {
                    Console.Write("보너스 번호 : [0]", Lotto);
                }
                else
                {
                    Console.WriteLine(Lotto);
                }

            }

        }
    }
}
