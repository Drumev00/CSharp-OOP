﻿using System;

using AnimalFarm.Models;

namespace AnimalFarm.Core
{
	public static class Engine
	{
		public static void Run()
		{
			try
			{
				string name = Console.ReadLine();
				int age = int.Parse(Console.ReadLine());

				Chicken chicken = new Chicken(name, age);
				Console.WriteLine(
					"Chicken {0} (age {1}) can produce {2} eggs per day.",
					chicken.Name,
					chicken.Age,
					chicken.ProductPerDay);
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(ae.Message);
			}
		}
	}
}
