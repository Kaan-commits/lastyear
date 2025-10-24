using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSP
{
    internal class Silindir : Daire
    {
        public double Yukseklik { get; set; }

       public override double Hesapla()
        {
          return base.Hesapla() * Yukseklik;
        }
    }
}