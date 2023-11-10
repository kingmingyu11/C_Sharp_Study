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

namespace Digitahwatch2
{
    public partial class Form1 : Form
    {
        private DateTime NowTime;
        public Form1()
        {
            InitializeComponent();
        }
        
        public void GetTime()
        {
            NowTime = DateTime.Now;
        }
        public void OutTime()
        {
            label1.Text = (NowTime + "\r\n");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    GetTime();
                    this.Invoke(new Action(() =>
                    {
                        OutTime();
                    }));
                }

            });
            Thread.Sleep(1000);

           /* Action time = () =>
            {
                while (true)
                {
                    label1.Text = DateTime.Now.ToString();
                    Thread.Sleep(1000);
                }
            };

            Thread t1 = new Thread(new ThreadStart(time));
            t1.Start();*/


           
           
           
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
