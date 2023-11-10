using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace propertyApp003
{
    internal class Program
    {
        class Birthdayinfo
        {
            private string name;
            private DateTime birthday;

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public DateTime Birthday
            {
                get
                {
                    return birthday ;
                }
                set
                {
                    birthday = value;
                }
            }
            public int Age
            {
                get
                {
                    return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
                }
            }
        }
        static void Main(string[] args)
        {
            Birthdayinfo birth = new Birthdayinfo();
            birth.Name = "서현";
            birth.Birthday = new DateTime(1991, 6, 28);
            Console.WriteLine($"Name: {birth.Name}");
            Console.WriteLine($"Birthday: {birth.Birthday.ToShortDateString()}");

            Console.WriteLine($"age: {birth.Age}");

        }
    }
}
