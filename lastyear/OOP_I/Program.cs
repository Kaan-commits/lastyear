using OOP_I;
using System;

namespace OOP_I
{
	internal static class Program
	{
		// Not the application's entry point; helper runner to avoid top-level statements conflict
		public static void Run()
		{
			Console.WriteLine("NYP");

			Urun urun = new Urun();
			urun.UrunID = 5;
			Console.WriteLine($"UrunID: {urun.UrunID}");
		}
	}
}
