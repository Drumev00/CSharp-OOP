using System;
using System.Collections.Generic;

using P05_BorderControl.Models;
using P05_BorderControl.Interfaces;

namespace P05_BorderControl
{
	class Program
	{
		static void Main(string[] args)
		{
			string command = string.Empty;
			List<IIdentifiable> citizens = new List<IIdentifiable>();

			while ((command = Console.ReadLine()) != "End")
			{
				string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				IIdentifiable enter = null;
				if (tokens.Length == 3)
				{
					string name = tokens[0];
					int age = int.Parse(tokens[1]);
					string id = tokens[2];
					enter = new Citizen(name, age, id);
					citizens.Add(enter);
				}
				else
				{
					string model = tokens[0];
					string id = tokens[1];
					IIdentifiable robot = new Robot(model, id);
					citizens.Add(robot);
				}
			}
			string invalidIdEnd = Console.ReadLine();
			foreach (var citizen in citizens)
			{
				if (citizen.Id.EndsWith(invalidIdEnd))
				{
					Console.WriteLine(citizen.Id);
				}
			}
		}
	}
}
