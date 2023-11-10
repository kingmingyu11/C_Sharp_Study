using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormStyle2
{
    //만들고 싶은 윈도우 <--- form 클래스 상속
    class MyClass : Form
    {
        
    }

    //program은 main함수만 ㄷ농작하도록
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            Application.Run(mc);
        }
    }
}
