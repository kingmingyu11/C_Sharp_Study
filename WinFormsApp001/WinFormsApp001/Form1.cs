using System.Diagnostics;

namespace WinFormsApp001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C#의 세상에 오신걸 환영합니다");
        }

        private void btn_Bigbutton_Click_1(object sender, EventArgs e)
        {

            //1.메시지박스사용
            MessageBox.Show("안녕하세요 윈도우 프로그랩입니다.");
            //2.디버그로그에출력
            Trace.WriteLine(string.Format($"{System.DateTime.Now}: 출력메시지"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "절대 누르지 말라고 하였는데.......";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
           Dispose();
        }
    }

}