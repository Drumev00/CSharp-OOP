using System;
using System.Collections.Generic;
using System.Linq;

using P07_FoodShortage.Interfaces;
using P07_FoodShortage.Models;

namespace P07_FoodShortage
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

			int peoples = int.Parse(Console.ReadLine());

			for (int i = 0; i < peoples; i++)
			{
				string[] info = Console.ReadLine().Split().ToArray();

				IBuyer buyer = null;

				if (info.Length == 3)
				{
					buyer = new Rebel(info[0], int.Parse(info[1]), info[2]);
				}
				else
				{
					buyer = new Citizen(info[0], int.Parse(info[1]), info[2], info[3]);
				}

				buyers.Add(info[0], buyer);
			}

			string name = Console.ReadLine();

			while (name != "End")
			{
				if (buyers.ContainsKey(name))
				{
					buyers[name].BuyFood();
				}

				name = Console.ReadLine();
			}

			int totalFood = buyers.Values.Select(x => x.Food).Sum();

			Console.WriteLine(totalFood);
		}
	}
}
