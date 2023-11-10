using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPapp013
{
    class Myclass
    {
        public int MyField1;
        public int MyField2;
        //깊은 복사
        public Myclass DeepCopy()
        {
            Myclass newCopy = new Myclass();
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;
            return newCopy;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Myclass source = new Myclass();
            source.MyField1 = 10;
            source.MyField2 = 20;

            //객체생성 ?일반적으로는 new
            //Myclass target = source;
            Myclass target =source.DeepCopy();
            target.MyField2 = 30;
            Console.WriteLine(source.MyField1 + " : " +  source.MyField2);
            Console.WriteLine(target.MyField1 + " : " + target.MyField2);


        }
    }
}
