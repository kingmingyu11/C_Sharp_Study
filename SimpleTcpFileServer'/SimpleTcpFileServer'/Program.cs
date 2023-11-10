using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTcpFileServer_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //인터넷주소만들고 포트만들기
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            int port = 13001;

               TcpListener server = new TcpListener(localAddr, port);
            server.Start();
            Console.WriteLine("서버시작....");

            //2.클라이언트아 접속할 소켓만들고클라이언트기다리기
            using (TcpClient client = server.AcceptTcpClient())
            {
                Console.WriteLine("연결 성공");


                //사진 전송

                using(NetworkStream stream = client.GetStream())
                {
                   byte[] data =  File.ReadAllBytes(@"./캡처.png");
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("전송이 완료되었습니다");
                }


            }
            server.Stop();
        }
    }
}




























































































































































































