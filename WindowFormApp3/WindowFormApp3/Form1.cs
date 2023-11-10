using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFormApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // progressBar1.Maximum = 1000; 속성에서  설정하거나 여기서 설정
            //스레드나 task 중에 하나

            Task task = Task.Run(() => {


                for (int i = 1; i <= 10000; i++)
                {
                    //프로세스 작업장 스레드 일꾼- 
                    Invoke(new Action(() => //Invoke는 회피....
                    {
                        progressBar1.Value = i;
                        Thread.Sleep(1);
                    }));
                }                   
            });

         
      
        }
    }
}
