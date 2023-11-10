using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewApp01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Admin\Desktop\사람인\KakaoTalk_20230727_155147592_01.jpg";
            pictureBox1.Load(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Admin\Desktop\사람인\캡처.PNG";
            pictureBox1.Load(path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Admin\Desktop\ㅎㄹ.jpg";
            pictureBox1.Load(path);
        }
       
    }
}
