using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intarr001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 2]
            {
                {1,2 },{2,3 }
            };
            for(int i =0;i<2; i++)
            {
                for(int j =0;j<2;j++)
                {
                    Console.Write(arr[i,j]+"\t");
                }
                Console.WriteLine();
            }
            
           
        }
            }
        }
            
            
            


        
    

