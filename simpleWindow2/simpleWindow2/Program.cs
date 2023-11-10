using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simpleWindow2
{
    internal class MainApp :Form
    {       
        static void Main(string[] args)
        {
            MainApp form = new MainApp();

            form.Click += new EventHandler(
                (sender, EventArgs) =>
                {
                
                    Console.WriteLine("윈도우닫기...");
                    Application.Exit();
                }
                );
            Console.WriteLine("윈도우프로그램 시작...");
            Application.Run(form);

            Console.WriteLine("윈도우프로그램 종료...");
        }
    }
}
