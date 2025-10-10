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
            // console'a yazdırma
            Console.WriteLine("Console'a yazdırma örneği:");
            Console.WriteLine("Hello World!");

            // değişken tanımlama ve console'a yazdırma
            Console.WriteLine("Değişken tanımlama ve console'a yazdırma örnekleri:");
            int sayı = 12;
            char karakter = 'A';

            Console.WriteLine(sayı);
            Console.WriteLine(karakter);

            //if fonksiyonları
            Console.WriteLine("If Örneği:");
            if (sayı > 10)
            {
                Console.WriteLine("Sayı 10'dan büyük.");
            }
            else
            {
                Console.WriteLine("Sayı 10'dan küçük veya eşittir.");
            }

            // döngü örneği
            Console.WriteLine("Döngü Örnekleri:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Döngü sayısı: " + i);
            }
        }
    }
}