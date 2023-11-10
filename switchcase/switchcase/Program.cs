using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace switchcase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int num;
            Console.Write("단을 입력하세요 : ");
            num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 3:
                    
                   for(int i = 1; i<=9; i++)
                    {
                        Console.WriteLine($"{num} * {i} = {num *i}");
                    }

                    break;
                case 4:

                    for (int i = 1; i <= 9; i++)
                    {
                        Console.WriteLine($"{num} * {i} = {num * i}");
                    }

                    break;
                case 5:

                    for (int i = 1; i <= 9; i++)
                    {
                        Console.WriteLine($"{num} * {i} = {num * i}");
                    }

                    break;
                case 6:

                    for (int i = 1; i <= 9; i++)
                    {
                        Console.WriteLine($"{num} * {i} = {num * i}");
                    }

                    break;



            }




        }

    }
    }

