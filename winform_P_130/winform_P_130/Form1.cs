﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_P_130
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ijumsu;
            string sHakjum;

            if(textBox1.Text == "")
            {
                MessageBox.Show("점수를 입력하세요", "경고 1");
                goto Naga;
            }
            ijumsu = int.Parse(textBox1.Text);
            if(ijumsu > 100 || ijumsu < 0)
            {
                MessageBox.Show("0~100 사이의 점수를 입력하세요", "경고 2");
                goto Naga;
                
            }
            if (ijumsu >= 96)
                sHakjum = "A+";
            else if (ijumsu >= 91)
                sHakjum = "A0";
            else if (ijumsu >= 86)
                sHakjum = "B+";
            else if (ijumsu >= 81)
                sHakjum = "B0";
            else if (ijumsu >= 76)
                sHakjum = "C+";
            else if (ijumsu >= 71)
                sHakjum = "C0";
            else if (ijumsu >= 66)
                sHakjum = "D+";
            else if (ijumsu >= 60)
                sHakjum = "D0";
            else
                sHakjum = "F:재수강";
            textBox2.Text = sHakjum;

        Naga: textBox1.Focus();
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.TextLength;
        }
    }
}
