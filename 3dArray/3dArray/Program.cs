using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[4, 3, 2] // 자바에서는 int [][][]
            {
                {{1,2} , {3,4}, {4,5} },
                {{1,4 },{2,5 },{3,6 } },
                {{6,5 },{4,3 },{2,1 } },
                {{6,3 },{5,2 },{4,1 } }
            };

        }
    }
}
