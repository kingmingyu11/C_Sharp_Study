using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAp003
{
    class MyClass
    {
        private delegate void RunDelegate(int i);

        private void RunThis(int val)
        {
            //출력 10진수1024
            Console.WriteLine(val);
        }
        private void RunThat(int val)
        {
            //출력 16진수 1024 ---400
            Console.WriteLine($"{val:X}");
        }
        public void Perform()
        {
            //델리게이트 객체생성
            RunDelegate run = new RunDelegate(RunThis);
            //10진수출력
            run(1024);
            // 16진수출력
            run = new RunDelegate(RunThat);
            //run = RunThat;

            run(1024);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.Perform();
        }
    }
}
