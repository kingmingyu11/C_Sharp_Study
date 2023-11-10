using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p._88_Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;
            int sum = 0;
            j = int.Parse(textBox1.Text);

            textBox2.Text = "";

            for( i = 1; i<=j ; i++ )
            {
                sum = sum + i;
                textBox2.Text = textBox2.Text + i + " + ";

            }
            textBox2.Text = textBox2.Text.TrimEnd('+',' ')+ " = "+ sum;
        }
    }
}
