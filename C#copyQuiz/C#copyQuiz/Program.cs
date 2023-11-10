using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_copyQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string path = "C:\\Temp\\a.txt";

            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs,Encoding.UTF8);

            sw.WriteLine("hi");
            sw.Flush();
            sw.Close();

            File.Copy(path, "C:\\Temp\\b.txt");*/

            string path = "C:\\Temp\\88.txt";
            FileStream fs = new FileStream(path, FileMode.Create);

            StreamWriter sw = new StreamWriter(fs,Encoding.UTF8 );
            sw.WriteLine("오늘은 개운하다 ");
            sw.Flush();
            sw.Close();
            //File.Copy(path, "C:\\Temp\\hihi.txt");
            byte[] buffer = File.ReadAllBytes(path);

            string path2 = "C:\\Temp\\b.txt";
            File.WriteAllBytes(path2, buffer);
        }
    }
}
