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

namespace winTcpServerQuiz
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
        }
        public class Haksu 
        { 
              public string text1{ get; set; }
            public string text2 { get; set; }   
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string 서버 = "127.0.0.1";
            int port = 13000;
            client = new TcpClient(서버, port);
            stream = client.GetStream();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Haksu haksu = new Haksu();
            haksu.text1 = textBox1.Text;
            haksu.text2 = textBox2.Text;
            string json = System.Text.Json.JsonSerializer.Serialize(haksu);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            stream.Write(bytes,0,bytes.Length);
        }
    }
}
