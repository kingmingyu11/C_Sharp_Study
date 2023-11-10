using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryStreamQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Temp\\abc.txt";
            StreamReader sr = new StreamReader(path);
            string txt =sr.ReadToEnd();
            sr.Close(); // =sr.Dispose(); < c#에서는 dispose를 자주씀
            Console.WriteLine(txt);

             MemoryStream ms = new MemoryStream();
            byte[] strBytes = Encoding.UTF8.GetBytes(txt);
            ms.Write(strBytes, 0, strBytes.Length);
            
            StreamReader sr2 = new StreamReader(ms,Encoding.UTF8,true);
            string txt2 = sr2.ReadToEnd();
            Console.Write(txt2);








        }
    }
}
