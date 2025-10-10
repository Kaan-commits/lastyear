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
            consoleYazdir();

            // değişken tanımlama ve console'a yazdırma
            Console.WriteLine("\nDeğişken tanımlama ve console'a yazdırma örnekleri:\n");
            int sayı = 12;
            char karakter = 'A';

            Console.WriteLine(sayı);
            Console.WriteLine(karakter);

            //if fonksiyonları
            Console.WriteLine("\nIf Örneği:\n");
            if (sayı > 10)
            {
                Console.WriteLine("Sayı 10'dan büyük.");
            }
            else
            {
                Console.WriteLine("Sayı 10'dan küçük veya eşittir.");
            }

            // döngü örneği
            Console.WriteLine("\nDöngü Örnekleri:\n");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Döngü sayısı: " + i);
            }

            /* Sonsuz Döngü Örneği:
            for (;;)
                Console.WriteLine("Bu bir sonsuz döngüdür.");
            */

            while (sayı > 0)
            {
                Console.WriteLine("Sayı: " + sayı);
                sayı--;
            }

            //diziler
            Console.WriteLine("\nDizi Örneği:");
            int[] sayilar = { 1, 2, 3, 4, 5 };
            int[] numbers = new int[5]; // boş dizi tanımlama
            foreach (int s in sayilar)
            {
                Console.WriteLine("Dizi elemanı: " + s);
            }
            foreach (int s in numbers)
            {
                Console.WriteLine("Boş dizinin elemanı: " + s); // tüm elemanlar 0'dır
            }
        }

        static void consoleYazdir()
        {
            Console.WriteLine("\nConsole'a yazdırma örneği:\n");
            Console.WriteLine("Hello World!");
        }
    }
}