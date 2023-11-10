using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinTcpClientQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Haksu
        {
            public string text1 { get; set; }
            public string text2 { get; set; }


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress adress = IPAddress.Parse("127.0.0.1");
            int port = 13000;

            TcpListener tcpListener = new TcpListener(adress, port);
            tcpListener.Start();

            richTextBox1.AppendText("연결을 기다리는중 문이노를 기다리는중..\n");
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Task task = Task.Run(() =>
                {
                    richTextBox1.AppendText("연결 성공");
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = new byte[256];
                        int bytes;
                        while ((bytes = stream.Read(data, 0, data.Length)) != 0)
                        {
                            string s = bytes.ToString();

                        }
                    }
                });
            }

        }
    }
}
