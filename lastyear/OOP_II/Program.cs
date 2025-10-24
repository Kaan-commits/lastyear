using OOP_II;
using System;

namespace OOP_II
{
	internal static class Program
	{
		// Not the application's entry point; helper runner to avoid top-level statements conflict
		public static void Run()
		{
			Console.WriteLine("Kalıtım-CokSekillilik");

			Araba araba = new Araba();
			Ferrari ferrari = new Ferrari();
			Bmw bmw = new Bmw();

			araba.Sur();
			ferrari.Sur();
			bmw.Sur();
		}
	}
}
