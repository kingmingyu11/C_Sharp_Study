using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace serializationQuiz
{
    class Student
    {
        public int STID { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "student.json";
            using (Stream ws = new FileStream(path, FileMode.Create))
            {
                Student sd = new Student();
                sd.STID = 12345;
                sd.Name = "홍길동";
                sd.Major = "스마트팩토리";



            string jsonstring = JsonSerializer.Serialize<Student>(sd); // 직렬화
                byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonstring);
                ws.Write(jsonBytes, 0, jsonBytes.Length);
            }
            using(Stream rs = new FileStream(path,FileMode.Open))
            {
                byte[] jsonBytes = new byte[rs.Length];
                rs.Read(jsonBytes, 0, jsonBytes.Length);
                string jsonString = Encoding.UTF8.GetString(jsonBytes);

                Student sd2 = JsonSerializer.Deserialize<Student>(jsonString);
                Console.WriteLine(sd2.STID);
                Console.WriteLine(sd2.Name);
                Console.WriteLine(sd2.Major);

            }

        }
    }
}
