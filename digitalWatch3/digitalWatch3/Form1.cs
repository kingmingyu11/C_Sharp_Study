using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace digitalWatch3
{
    public partial class Form1 : Form
    {
        private TimeSpan time = TimeSpan.Zero;

        public Form1()
        {
            InitializeComponent();
         
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = time.ToString("'mm': 'ss'");
            time = time.Add(TimeSpan.FromSeconds(1));
        }
    }
}
