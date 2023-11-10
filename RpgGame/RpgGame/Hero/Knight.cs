using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RpgGame.Hero
{
    internal class Knight
    {
        public Knight(string name)
        {
            Name = name;
        }
        public string Attack()
        {
            return "활을 쏩니다.";
        }
    }
}
