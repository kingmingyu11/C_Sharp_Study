using System.Security.Cryptography.X509Certificates;

namespace LinqConosoleApp02
{
    //class Profile
    //{
    //    public string Name { get; set; }
    //    public int Height { get; set; }
    //}

    class Student
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students =
            {
                new Student() {Name = "정우성",Height=186},
                new Student() {Name = "김태희",Height=158},
                new Student() {Name = "고현정",Height=172},
                new Student() {Name = "이문세",Height=178},
                new Student() {Name = "하하",Height=171},

            };
            var s1 = from s in students
                            where s.Height >= 178
                            orderby s.Height
                            select s;
            //    Profile[] arrProfile =
            //    {
            //        new Profile() { Name = "정우성", Height = 186 },
            //        new Profile() { Name ="김태희", Height = 158 },
            //        new Profile() {Name = "고현정",Height = 172},
            //        new Profile() {Name = "이문세",Height = 178},
            //        new Profile() {Name = "하하",Height = 171},

            //    };
            //var profiles = from p in arrProfile
            //               where p.Height < 175
            //               orderby p.Height
            //               select p;
            //foreach (var p in profiles)
            //    Console.WriteLine($"{p.Name} {p.Height}");
        }
    }
}