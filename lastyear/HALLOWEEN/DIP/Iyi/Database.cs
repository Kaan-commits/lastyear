using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Iyi
{
    internal abstract class Database
    {
        public abstract List<string> listele();
        public abstract void ekle(string str);
    }
}