﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrayapp02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[10];
            
            for(int i= 0,cnt = 70; i<arr.Length; i++,cnt/=7)
            {
                arr[i] = cnt;
                Console.WriteLine(arr[i]);
            }
          

            
        }
    }
}
