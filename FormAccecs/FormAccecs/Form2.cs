using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAccecs
{
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(object form)
        {
            InitializeComponent();
            frm1= (Form1)form;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm1.label1.Text = "Form2ㅇㅔ서 변경하였습니다.";
        }
    }
}
