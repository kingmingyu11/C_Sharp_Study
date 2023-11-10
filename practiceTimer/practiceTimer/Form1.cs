using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practiceTimer
{
    public partial class Form1 : Form
    {
        private int count = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task = Task.Run(async() =>
            {
                while(true)
                {
                    Invoke((Action)(()=>label1.Text = (count++).ToString()));
                    await Task.Delay(1000);
                }

            });

        }
    }
}
