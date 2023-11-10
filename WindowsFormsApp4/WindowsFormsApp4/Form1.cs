using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    
    public partial class Form1 : Form
    {
        private int cnt = 0;
        private Thread t1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         t1 = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Invoke((Action)(() => label1.Text = cnt++ + ""));

                        Thread.Sleep(500);

                    }catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);//디버그피하기..?
                        break;
                    }
                    
                }

            });
            t1.IsBackground = true;
            t1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.Interrupt();
        }
    }
}
