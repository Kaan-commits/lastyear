using System;
using OCP;

namespace lastyear.OCP
{
    class Program
    {
        // Not the application's entry point; helper runner to avoid top-level statements conflict
        static void Main(string[] args)
        {
            Console.WriteLine("OCP - Open/Closed Principle");

            //soru: text ve xml dosyalardan veri okuyan sınıfları yaz...

            TextDosya text = new TextDosya();
            XmlDosya xml = new XmlDosya();
            JsonDosya json = new JsonDosya();

            DosyaYoneticisi dosyaYoneticisi = new DosyaYoneticisi(json);
            System.Console.WriteLine(dosyaYoneticisi.VerileriOku());
        }
    }
}