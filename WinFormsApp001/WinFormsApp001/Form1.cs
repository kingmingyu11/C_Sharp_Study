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
            MessageBox.Show("C#�� ���� ���Ű� ȯ���մϴ�");
        }

        private void btn_Bigbutton_Click_1(object sender, EventArgs e)
        {

            //1.�޽����ڽ����
            MessageBox.Show("�ȳ��ϼ��� ������ ���α׷��Դϴ�.");
            //2.����׷α׿����
            Trace.WriteLine(string.Format($"{System.DateTime.Now}: ��¸޽���"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "���� ������ ����� �Ͽ��µ�.......";
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