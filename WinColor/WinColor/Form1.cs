using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinColor
{
    public partial class Form1 : Form
    {
        private int R, G, B;//1번 변수선언해줌

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*Color color = Color.FromArgb(R, G, B);
            panel1.BackColor =( color); */

            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           /* R = trackBar1.Value;
            panel1.Invalidate();*/
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
          /*  G= trackBar2.Value;
            panel1.Invalidate();*/
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
          /* B=trackBar3.Value;
            panel1.Invalidate();*/
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            R = trackBar1.Value;
            panel1.Invalidate(); //인벨리드데이트 -->> 새로 그리겠다 운영체제야.

        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            G = trackBar2.Value;
            panel1.Invalidate(); //인벨리드데이트 -->> 새로 그리겠다 운영체제야.

        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            B=trackBar3.Value;
            panel1.Invalidate(); //인벨리드데이트 -->> 새로 그리겠다 운영체제야.

        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
