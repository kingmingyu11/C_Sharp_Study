using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usingapp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using( BinaryWriter bw = new BinaryWriter(new FileStream("a.dat",FileMode.Create)))
            {
                bw.Write(int.MaxValue);
                bw.Write("Good mornig");
                bw.Write(uint.MaxValue);
                bw.Write("안녕하세요");
                bw.Write(double.MaxValue);
            }
        }
        }
    }

