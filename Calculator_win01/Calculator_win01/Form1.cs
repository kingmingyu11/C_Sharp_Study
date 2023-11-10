using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_win01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val1, val2;

             val1=  int.Parse(textBox1.Text);
            val2= int.Parse(textBox2.Text);

            int result;
            result = val1 + val2;

            textBox3.Text = result.ToString(); 
        }
    }
}
