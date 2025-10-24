using System;
using LSP;

namespace lastyear.LSP
{
    class Program
    {
        // Not the application's entry point; helper runner to avoid top-level statements conflict
        static void Main(string[] args)
        {
            Console.WriteLine("LSP - Liskov Substitution Principle");

            //soru: text ve xml dosyalardan veri okuyan sınıfları yaz...

            Daire daire = new Daire() { Yaricap = 3 };
            Silindir silindir = new Silindir() { Yaricap = 3, Yukseklik = 5 };

            Hesaplayici hesaplayici = new Hesaplayici();
            System.Console.WriteLine(" Daire Alanı: " + hesaplayici.Hesapla(daire));
            System.Console.WriteLine(" Silindir Alanı: " + hesaplayici.Hesapla(silindir));
        }
    }
}