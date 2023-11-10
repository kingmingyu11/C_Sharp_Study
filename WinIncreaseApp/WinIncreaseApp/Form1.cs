using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinIncreaseApp
{
    public partial class Form1 : Form
    {
        private int cnt = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => //무명함수
            {
            
            });
            t.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
