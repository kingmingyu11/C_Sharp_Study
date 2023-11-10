using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation장풍쏘기
{
    public partial class Form1 : Form
    {
        private int x, y;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x= x+150;

           
            pictureBox1.Location = new Point(x,y); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x=  pictureBox1.Location.X;
            y= pictureBox1.Location.Y;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}
