using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RpgGame.Common
{
    internal class Story
    {
        public void InitStory()
        {
            Console.WriteLine("때는 Bc.1700년 어둠이 내리고 악은 드디어 선을 무너뜨렸다.");
            Thread.Sleep(1000);
            Console.WriteLine("영웅이 탄생해야 하는 시기가 도래했다.");
            Thread.Sleep(1000);
            Console.WriteLine("드디어 시대의 영웅이 탄생하는데 ....");
            Thread.Sleep(1000);
        }
    }
}
