using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSize
{
    class MainApp : Form
    {
        static void form_MouseDown(object sender, MouseEventArgs e)
        {
            Form form = (Form)sender; //Down Casting
            int oldWjdth = form.Width;
            int oldHeight = form.Height;

            if(e.Button == MouseButtons.Right)
            {
                if(oldHeight < oldWjdth)
                {
                    form.Width= oldWjdth;
                    form.Height = oldHeight;
                }
                Console.WriteLine("오른쪽 마우스 버튼이 클릭되었습니다.");
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (oldWjdth < oldHeight)
                {
                    form.Width = oldWjdth;
                    form.Height = oldHeight;
                }
                Console.WriteLine("왼쪽 마우스 버튼이 클릭되었습니다. ");
            }

        }
        static void Main(string[] args)
        {
            MainApp form = new MainApp();
            form.Width = 500;
            form.Height = 500;

            //마우스 이벤트 처리
            //1.왼쪽 마우스 버튼 눌렀을때
            form.MouseClick += form_MouseDown;

            //2. 오른쪽 마우스 버튼 눌렀을때
            Application.Run(form);
        }
    }
}
