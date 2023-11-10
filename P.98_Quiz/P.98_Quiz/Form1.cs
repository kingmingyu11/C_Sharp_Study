using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P._98_Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Number = 0;
        DateTime NowTime;
        public void GetNumber()
        {
            Number++;
        }
        public void OutNumber()
        {
            textBox1.AppendText(Number + "\r\n");
            
        }
        public void GetTime()
        {
            NowTime = DateTime.Now;
        }
        public void OutTime()
        {
            textBox2.AppendText(NowTime+ "\r\n");
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            /* for(int i = 1; i < 100; i++)
             {
                 GetNumber();
                     OutNumber();
                 GetTime();
                 OutTime();
                 System.Threading.Thread.Sleep(1000);
             }*/
            for (int i = 0; i <= 5; i++)

            {

                GetNumber();

                this.Invoke(new Action(() =>

                {

                    OutNumber();

                }));

                GetTime();

                this.Invoke(new Action(() =>

                {

                    OutTime();

                }));

                Thread.Sleep(1000);

            }
        }
    }
}
