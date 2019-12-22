using System;

using P03_Ferrari.Models;

namespace P03_Ferrari
{
	class Program
	{
		static void Main(string[] args)
		{
			string name = Console.ReadLine();
			Ferrari ferrari = new Ferrari(name);
			Console.WriteLine(ferrari);
		}
	}
}
