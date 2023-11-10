using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMouseApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseClick += UserMouseEvent;
        }
        private void UserMouseEvent(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Trace.WriteLine($"마우스 {e.Button} 클릭 ({e.X},{e.Y})");
            }
        }
    }
}
