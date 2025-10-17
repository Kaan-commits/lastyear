using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_I
{
    internal class Urun
    {
        private int id;

        //özellikl
        //1- property'nin kullanacağı değikeni tanımla...
        public int UrunID
        {
            get { return id; }
            set { id = value; }
        }

        //C# 3.0
        //ihtiyacı olan değişkeni kendisi tanımlar...
        public string UrunAdi { get; set; }

        public Urun(int id)
        {

        }

        public Urun()
        {

        }
        
        //Yıkıcı metod
        //bir sınıfta bir tane olabilir
        //performans açısından kullanma
        //IDisposable arayüzü kullan
        ~Urun()
        {

        }

    }
}