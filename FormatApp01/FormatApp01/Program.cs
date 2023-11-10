using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatApp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2023, 03, 04, 23, 18, 22);
            Console.WriteLine("12시간 형식 : {0:yyyy-MM-dd tt hh:mm:ss (ddd)}",dt);
            Console.WriteLine("24시간 형식 : {0:yyyy-MM-dd tt HH:mm:ss (ddd)}", dt);

            CultureInfo ciko = new CultureInfo("ko-KR");
            Console.WriteLine();
            Console.WriteLine(dt.ToString("yyyy-MM-dd hh:mm:ss (ddd)",ciko));
            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (dddd) ", ciko));
            Console.WriteLine(dt.ToString(ciko));

            CultureInfo ciEn = new CultureInfo("en-US");
            Console.WriteLine();
            Console.WriteLine(dt.ToString("yyyy-MM-dd tt hh:mm:ss (ddd)"), ciEn);
            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss (ddd)"), ciEn);
            Console.WriteLine(dt.ToString(ciEn));

            //수정
            DateTime Dt = DateTime.Now;
            Console.WriteLine($"{Dt:yyyy-MM-dd}");
        }
    }
}
