using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_I
{
	internal interface IAraba
	{
        public void Sur();

        public string Renk { get; set; }

        //c# 6 veya 7
        //Özel Durum
        public void Islem()
        {
            System.Console.WriteLine("Araba İşlemleri...");
        }
	}
}
