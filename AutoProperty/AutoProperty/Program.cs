using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProperty
{

    class BirthdayInfo
    {
        public string Name { get; set; } = "Unknown";
        public DateTime Birthday { get; set; } = new DateTime(1, 1, 1);
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                BirthdayInfo birth = new BirthdayInfo();
                Console.WriteLine(birth.Name);
                Console.WriteLine(birth.Birthday.ToShortDateString());
                Console.WriteLine(birth.Age);

                birth.Name = "서현";
                birth.Birthday = new DateTime(1991, 6, 28);
                Console.WriteLine(birth.Name);
                Console.WriteLine(birth.Birthday.ToShortDateString());
                Console.WriteLine(birth.Age);

            }
        }
    }
}
