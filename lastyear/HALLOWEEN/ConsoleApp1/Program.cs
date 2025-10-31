using System;
using ConsoleApp1;

namespace lastyear.ConsoleApp1
{
    class Program
    {
        // Not the application's entry point; helper runner to avoid top-level statements conflict
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
        }

        void Test1()
        {
            System.Console.WriteLine("test 1");
        }
        void Test2()
        {
            System.Console.WriteLine("test 2");
        }

        int kareAl(int s)
        {
            return s * s;
        }

        void Test3(string s)
        {
            System.Console.WriteLine("test " +s);
        }

        Temsilci temsilci = new Temsilci(Test1);
        
        temsilci += Test2;
        //temsilci += Test3; //Olmaz
        //temsilci += kareAl(); //Olmaz
        temsilci += Test2;
        temsilci -= Test2;
        temsilci();

        buton buton = new buton();
        buton.
    }
}