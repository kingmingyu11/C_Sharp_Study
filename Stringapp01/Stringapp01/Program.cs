using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stringapp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string greeting = "Good Morning";

            Console.WriteLine(greeting);
            //indexof
            Console.WriteLine($"{greeting.IndexOf("morning")}");
            Console.WriteLine($"{greeting.IndexOf("d")}");
            //lastindexOf()
            Console.WriteLine($"{greeting.LastIndexOf("good")}");
            Console.WriteLine($"{greeting.LastIndexOf("o")}");
            //StartsWith()
            Console.WriteLine($"starts with: {greeting.StartsWith("good")}");
            Console.WriteLine($"starts with: {greeting.StartsWith("morning")}");

            //Endswith()
            Console.WriteLine($"Ends with: {greeting.EndsWith("good")}");
            Console.WriteLine($"End with: {greeting.EndsWith("morning")}");

            //contains()
            Console.WriteLine($"contains EVEING: {greeting.Contains("Evening")}");
            Console.WriteLine($"Ends with: {greeting.EndsWith("good")}");

            //Replace()
            Console.WriteLine($"Replace Evening: {greeting.Replace("Morning","Evening")}");
        }
    }
}
