using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Iyi
{
    internal class SQL : Database
    {
        List<string> veriler = new List<string>
        {
            "SQL 1", "SQL 2", "SQL"
        };
        public override void ekle(string str)
        {
            veriler.Add(str);
        }

        public override List<string> listele()
        {
            return veriler;
        }
    }
}