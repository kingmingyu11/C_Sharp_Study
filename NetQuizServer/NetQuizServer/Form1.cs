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

namespace NetQuizServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            IPAddress 서버아이피 = IPAddress.Parse("127.0.0.1");
            int port = 13000;

            TcpListener tcp서버 = new TcpListener(서버아이피, port);
            tcp서버.Start();

            while (true)
            {
                TcpClient client = await tcp서버.AcceptTcpClientAsync();

                Task task = Task.Run(() => HandleClient(client));

            }
        }
        private async void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = new byte[512];

            int bytes;

            while((bytes = await stream.ReadAsync(data, 0,data.Length)) != 0) {
            
            string message = Encoding.UTF8.GetString(data,0,bytes);

            
            }
            stream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
