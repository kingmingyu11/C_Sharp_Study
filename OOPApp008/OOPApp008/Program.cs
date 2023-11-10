using OOPApp008;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPApp008
{
    //도형 클래스를 만든다
    //삼각혛ㅇ
    //사각형
    //원
    //공통메서드 draw()구현 각클래스 오버라이딩
    class Newjeans
    {
        public virtual void song()
        {
            Console.WriteLine("디토");
        }
    }
    class Haerin : Newjeans
    {
        public override void song()
        {
            Console.WriteLine("Hype Boy");
        }
    }
    class Minji : Newjeans
    {
        public override void song()
        {
            Console.WriteLine("cookie");
        }
    }
    class Hani : Newjeans
    {
        public override void song()
        {
            Console.WriteLine("attention");
        }
    }
      
}


    

    internal class Program
    {
        static void Main(string[] args)
        {
            
        Newjeans[] nw = new Newjeans[4];
        nw[0] = new Newjeans();
        nw[1] = new Haerin();
        nw[2] = new Minji();
        nw[3] = new Hani();

        for(int i = 0 ; i < nw.Length; i++)
        {
            nw[i].song();
        }

        
           
        }
    }

