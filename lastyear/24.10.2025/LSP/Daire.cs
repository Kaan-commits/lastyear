using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    internal class Daire
    {
        public double Yaricap { get; set; }

        public virtual double Hesapla()
        {
            return Math.PI * Yaricap * Yaricap;
        }
    }
}