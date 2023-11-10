using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace fileapp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //임베디드 프로그래밍 50% i/o입출력
            //리눅스의 모든것이 File --> low level - > byte[]


            // FileStream fs = File.Create("c:\\Temp\\a.dat");
            // File.Copy("c:\\Temp\\a.dat","c:\\Temp\\d.dat");
            try
            {
                FileInfo file = new FileInfo("c:\\Temp\\b.dat");
                FileStream fs = file.Create();//생성]
                fs.Close();
                FileInfo src = new FileInfo("c:\\Temp\\b.dat");
                FileInfo dst = src.CopyTo("c:\\Temp\\e.dat");//복사
                File.Delete("C:\\Temp\\b.dat");
                FileInfo delete_file = new FileInfo("c:\\Temp\\e.dat");
                delete_file.Delete();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
