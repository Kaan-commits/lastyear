using System;
using DIP.Iyi;
using DOP.Iyi;

namespace lastyear.DIP
{
    class Program
    {
        // Not the application's entry point; helper runner to avoid top-level statements conflict
        static void Main(string[] args)
        {
            System.Console.WriteLine("DIP - Dependency Inversion Principle");

            SQL sQL = new SQL();
            Oracle oracle = new Oracle();
            DatabaseManager databaseManager = new DatabaseManager(oracle);

            foreach (string str in databaseManager.Listele())
            {
                System.Console.WriteLine(str);
            }

            //Prop Injection
            DatabaseManager databaseManager2 = new DatabaseManager();
            databaseManager2.PropInjection = sQL;

            foreach (string str in databaseManager2.Listele())
            {
                System.Console.WriteLine(str);
            }

            //Method Injection
            DatabaseManager databaseManager3 = new DatabaseManager();
            databaseManager3.MethodInjection(oracle);

            foreach (string str in databaseManager3.Listele())
            {
                System.Console.WriteLine(str);
            }
        }
    }
}