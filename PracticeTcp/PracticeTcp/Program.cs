using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PracticeTcp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //주소생성
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            //포트생성
            int port = 13000;
            //서버객체 만들기
            TcpListener server = new TcpListener(localAddr,port);
                server.Start();
            Console.WriteLine("서버를 시작합니다");

            using (TcpClient client = server.AcceptTcpClient())
            {
                Console.WriteLine("연결에 성공했습니다");
                //클라이언트에 메시지 보낼준비
                //3. 소켓에 write할준비
                using (NetworkStream stream = client.GetStream())
                {
                    string response = "안녕하세요 클라이언트님";
                    byte[] data = Encoding.UTF8.GetBytes(response); 

                    //데이터전송
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"전송한 메시지 {response}");




                }

            }
            server.Stop();

        }
    }
}
