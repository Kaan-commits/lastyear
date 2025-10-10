using System;

namespace degiskenler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //açıklama satırı
            /*
             Çoklu açıklama satırı
            */
            // console'a ekrana yazdırma
            Console.WriteLine("Hello World!");

            // değişken tanımlama ve console'a yazdırma
            int sayı = 12;
            char karakter = 'A';

            Console.WriteLine(sayı);
            Console.WriteLine(karakter);

            //if fonksiyonları
            if (sayı > 10)
            {
                Console.WriteLine("Sayı 10'dan büyüktür.");
            }
            else
            {
                Console.WriteLine("Sayı 10'dan küçük veya eşittir.");
            }
        }
    }
}