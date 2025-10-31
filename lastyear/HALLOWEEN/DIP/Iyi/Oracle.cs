using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DIP.Iyi;

namespace DOP.Iyi
{
    internal class Oracle : Database
    {
        public override void ekle(string str)
        {

        }
        
        public override List <string> listele()
        {
            return new List<string>
            {
                "Oracle 1",
                "Oracle 2"
            };
        }
    }
}