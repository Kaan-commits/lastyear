using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    internal class DosyaYoneticisi
    {
        IOku _dosya;
        public DosyaYoneticisi(IOku dosya)
        {
            _dosya = dosya;
        }

        public string VerileriOku()
        {
            return _dosya.DosyadanOku();
        }
    }
}