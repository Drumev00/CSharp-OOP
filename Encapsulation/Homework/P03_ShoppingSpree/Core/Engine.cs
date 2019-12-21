using System;
using System.Collections.Generic;
using System.Linq;

using P03_ShoppingSpree.Models;

namespace P03_ShoppingSpree.Core
{
	public static class Engine
	{
		private static List<Person> people = new List<Person>();
		private static List<Product> products = new List<Product>();
		public static void Run()
		{
			try
			{
				InitializeClients();
				InitializeProducts();
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(ae.Message);
				return;
			}

			string command = string.Empty;

			while ((command = Console.ReadLine()) != "END")
			{
				try
				{
					string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
					string personsName = tokens[0];
					string productName = tokens[1];

					Person person = people.FirstOrDefault(p => p.Name == personsName);
					Product product = products.FirstOrDefault(p => p.Name == productName);

					person.BuyProduct(product);
				}
				catch (InvalidOperationException ioe)
				{
					Console.WriteLine(ioe.Message);
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.Message);
				}
			}
			Console.WriteLine(string.Join(Environment.NewLine, people));
		}

		private static void InitializeProducts()
		{
			string[] tokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < tokens.Length; i++)
			{
				string[] productsArgs = tokens[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
				string name = productsArgs[0];
				decimal price = decimal.Parse(productsArgs[1]);

				Product product = new Product(name, price);
				products.Add(product);
			}
		}

		private static void InitializeClients()
		{
			string[] tokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < tokens.Length; i++)
			{
				string[] peopleArgs = tokens[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
				string name = peopleArgs[0];
				decimal money = decimal.Parse(peopleArgs[1]);

				Person person = new Person(name, money);
				people.Add(person);
			}
		}
	}
}
