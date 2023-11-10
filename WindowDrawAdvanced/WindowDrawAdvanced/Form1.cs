using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowDrawAdvanced
{
    public partial class Form1 : Form
    {
        private bool drawCircle= false;
        private int elapsed = 0;
        public Form1()
        {
          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawCircle = false; //false일때 삼각형상ㅇ태임
            elapsed = 0;
            progressBar1.Value = 0;
            panel1.Invalidate();
            timer1.Start();

            
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (!drawCircle)
            {
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 50), new Point(300, 100) };
                g.FillPolygon(Brushes.Blue, points);
            }
            else
            {
                g.FillEllipse(Brushes.Blue, new Rectangle(100, 50, 200, 100));
                
            }
            
            /*Pen redPen = new Pen(Color.Red, 2);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Point pt1 = new Point(200,100);
            Point pt2 = new Point(100,100);
            Point pt3 = new Point(150,50);
            
            Point[] points = {pt1,pt2,pt3};
            g.DrawPolygon(redPen,points);
            g.FillPolygon(redBrush,points);*/


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsed += timer1.Interval;

            progressBar1.Value = Math.Min(elapsed,progressBar1.Maximum);

            if(elapsed >= progressBar1.Maximum)
            {
                drawCircle = true; //원이 되엇으면 상태를 true로 변겨
                panel1.Invalidate(); // 패널을 다시 그림
                timer1.Stop();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 3000; //프로그래스 바 3초를 이용
            progressBar1.Value = 0; //으로 초기화
            timer1.Interval = 100; // 타이머 인터벌 초기값이 100이다.
            //위 세줄은 컨트롤에서 작성하게되면 적지않아도 된다.
        }

    }
}
