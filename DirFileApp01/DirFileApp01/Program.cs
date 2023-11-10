﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirFileApp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directory;
            if (args.Length < 1)
                directory = ".";
            else
                directory = args[0];

            Console.WriteLine($"{directory} 디렉토리 정보");
            Console.WriteLine("- Directtories : ");
            var directories = ( from dir in Directory.GetDirectories(directory)
                        let info = new DirectoryInfo(dir)
                select new
                {
                    Name = info.Name,
                    Attributes = info.Attributes,
                }).ToList();

            foreach (var d in directories)
                Console.WriteLine($"{d.Name} : {d.Attributes}");
        }
    }
}