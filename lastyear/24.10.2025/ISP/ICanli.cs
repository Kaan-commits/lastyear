using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    internal interface ICanli
    {
        //ISP: Böyle kullanma
        //Atıl durumda üye yazılmalı...
        //Penguen, Devekuşu, Pelikan
        void Yuru();
        void Kos();
        void Uc();
        void Yuz();
    }
}