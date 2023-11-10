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

namespace number_Quiz
{
    public partial class Form1 : Form
    {
        private int count = 1;
        private CancellationTokenSource cts;
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task = Task.Run(async () =>
            {
                cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;
                while (true)
                {
                    Invoke((Action)(() => label2.Text = (count++).ToString()));
                   await Task.Delay(1000);

                    if (token.IsCancellationRequested) //취소요청이 오면
                    {
                        break;
                    }
                }

            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
