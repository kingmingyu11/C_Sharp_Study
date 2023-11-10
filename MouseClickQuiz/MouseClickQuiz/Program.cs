using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClickQuiz
{
    class MainApp : Form
    {
        static void form_MouseDown(object sender, MouseEventArgs e)
        {
            Form form = (Form)sender;
            int oldwidth = form.Width;
            int oldheight = form.Height;    
            
            if(e.Button == MouseButtons.Right)
            {
              
                Console.WriteLine($"X:{e.X}");
                Console.WriteLine($"Y;{e.Y}");
                Console.WriteLine(" 오른쪽 마우스 버튼이 클릭되었습니다.");
            }
            else if (e.Button == MouseButtons.Left)
            {
                
                Console.WriteLine($"X:{e.X}");
                Console.WriteLine($"Y:{e.Y}");
                Console.WriteLine(" 왼쪽 마우스 버튼이 클릭되었습니다.");
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Console.WriteLine($"X:{e.X}");
                Console.WriteLine($"Y:{e.Y}");
                Console.WriteLine(" 가운데 마우스 버튼이 클릭되었습니다.");
            }

        }
        static void Main(string[] args)
        {
            MainApp form = new MainApp();
            form.Width = 500;
            form.Height = 500;

            form.MouseClick += form_MouseDown;

            Application.Run(form);
        }
    }
}
