using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericApp006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> dic = new Dictionary<string,string>();

            dic["하나"] = "one";
            dic["둘"] = "two";
            dic["셋"] = "three";

            Console.WriteLine(dic["하나"]);
            Console.WriteLine(dic["둘"]);

        }
    }
}
