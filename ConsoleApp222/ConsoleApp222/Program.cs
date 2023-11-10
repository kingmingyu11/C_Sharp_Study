using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp222
{
    internal class Program
    {
        
        static void run(string path, byte[] picture)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {



                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(picture);
                bw.Flush();
                bw.Close();
            }
        }
        
        static void Main(string[] args)
        {
            string path = "C:\\Temp\\pic1.png";
            byte[] picture;
            using(FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryReader br= new BinaryReader(fs);
                picture = br.ReadBytes((int)fs.Length);
                br.Close();
            }

            Thread t1 = new Thread(()=>run(path,picture)); // 람다식...
            t1.Name = "Thread-1";
            t1.Start();
            t1.IsBackground = true; // 혹시 main이 죽ㅇ드면 같이죽겟다.
            t1.Join(); //main스레드가 기다려주는것
            
            
        }
    }
}
