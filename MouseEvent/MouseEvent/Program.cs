using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseEvent
{
    
    internal class MainApp :Form 
    {
        public void MyMouseHanlder(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Sender: {((Form)sender).Text}");
            Console.WriteLine($"X:{e.X}, Y:{e.Y}");
            Console.WriteLine($"Button : {e.Button} Clicks: {e.Clicks}");
            Console.WriteLine();        
        }
        public MainApp(string title)
        {
            this.Text = title;
            this.MouseDown += new MouseEventHandler(MyMouseHanlder);
        }
        static void Main(string[] args)
        {
            MainApp app = new MainApp("마우스 이벤트테스트");
            Application.Run(app);
        }
    }
}
