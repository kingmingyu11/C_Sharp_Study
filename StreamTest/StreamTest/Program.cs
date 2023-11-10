using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stream stream1 = new FileStream("a.dat", FileMode.Create);
            Stream stream2 = new FileStream("a.dat", FileMode.Open);
            Stream stream3 = new FileStream("a.dat", FileMode.OpenOrCreate);

            Stream stream4 = new FileStream("a.dat", FileMode.Truncate);
            Stream stream5 = new FileStream("a.dat", FileMode.Append);

            long someValue = 0x123456789ABCDEF0; //다 1 바이트값

            //1.파일스트림 생성
            Stream outStream = new FileStream("f.dat",FileMode.Create);
            //2.someValud(long 형식) 을 byte 배열로 변환
            byte[] wBytes = BitConverter.GetBytes(someValue);
            //3.변환할 byte 배열을  파일 스트림을 통해 파일에 기록
            outStream.Write(wBytes,0, wBytes.Length);
            //4.파일 스트림 닫기
            outStream.Close();




        }
    }
}
