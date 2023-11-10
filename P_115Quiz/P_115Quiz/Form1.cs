using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_115Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j, k;
            textBox1.Text = "";

            for (i = 2; i < 10; i = i + 4)
            {

                for (j = 1; j < 10; j++)
                {
                    for (k = 0; k <= 3; ++k)
                    {
                        textBox1.Text = textBox1.Text + (i + k) + " x " + j + " = ";
                        textBox1.Text = textBox1.Text + ((i + k) * j) + "     ";
                    }
                    textBox1.Text = textBox1.Text + Environment.NewLine;
                }
                textBox1.Text = textBox1.Text + Environment.NewLine;

            }


        } 
           
            }
    }

