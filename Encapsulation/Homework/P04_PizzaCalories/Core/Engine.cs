using System;

using P04_PizzaCalories.Models;

namespace P04_PizzaCalories.Core
{
	public static class Engine
	{
		static string pizzaName;
		static Dough dough;
		static Pizza pizza;
		public static void Run()
		{
			string ingredients = string.Empty;


			while ((ingredients = Console.ReadLine()) != "END")
			{
				try
				{
					string[] tokens = ingredients.Split(" ", StringSplitOptions.RemoveEmptyEntries);
					if (tokens[0] == "Pizza")
					{
						pizzaName = tokens[1];
					}
					else if (tokens[0] == "Dough")
					{
						dough = new Dough(tokens[1], tokens[2], int.Parse(tokens[3]));
						pizza = new Pizza(pizzaName, dough);
					}
					else if (tokens[0] == "Topping")
					{
						Topping topping = new Topping(tokens[1], int.Parse(tokens[2]));
						pizza.AddTopping(topping);
					}
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.Message);
					return;
				}
				catch (InvalidOperationException ioe)
				{
					Console.WriteLine(ioe.Message);
					return;
				}
			}
			Console.WriteLine(pizza);
		}
	}
}
