using System;

using P01_ClassBoxData.Models;

namespace P01_ClassBoxData.Core
{
	public static class Engine
	{
		public static void Run()
		{
			try
			{
				double length = double.Parse(Console.ReadLine());
				double width = double.Parse(Console.ReadLine());
				double height = double.Parse(Console.ReadLine());

				Box box = new Box(length, width, height);
				Console.WriteLine(box);
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(ae.Message);
			}
		}
	}
}
