﻿namespace LinqConsoleApp04
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }   
    internal class Program
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
 {
                 new Profile() {Name="정우성", Height=186},
                 new Profile() {Name="김태희", Height=158},
                 new Profile() {Name="고현정", Height=172},
                 new Profile() {Name="이문세", Height=178},
                 new Profile() {Name="하하", Height=171},

 };

            var listProfile = from p in arrProfile
                              orderby p.Height
                              group p by p.Height < 175 into g
                              select new { GroupKey = g.Key, Profiles = g };
            foreach(var Group in listProfile)
            {
                Console.WriteLine($"-175cm 미만: {Group.GroupKey}");
                foreach(var p in Group.Profiles)
                {

                    Console.WriteLine($">>{p.Name},{p.Height}");
                }
            }
        }
    }
}