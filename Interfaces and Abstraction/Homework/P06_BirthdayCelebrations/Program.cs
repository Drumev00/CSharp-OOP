using System;
using System.Collections.Generic;
using P06_BirthdayCelebrations.Interfaces;
using P06_BirthdayCelebrations.Models;

namespace P06_BirthdayCelebrations
{
	class Program
	{
		static void Main(string[] args)
		{
			List<IBirthable> citizens = new List<IBirthable>();
			string command = string.Empty;

			while ((command = Console.ReadLine()) != "End")
			{
				string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				IBirthable citizen = null;
				if (tokens[0] == "Citizen")
				{
					string name = tokens[1];
					int age = int.Parse(tokens[2]);
					string id = tokens[3];
					string birthdate = tokens[4];
					citizen = new Citizen(name, age, id, birthdate);
					citizens.Add(citizen);
				}
				else if (tokens[0] == "Pet")
				{
					string name = tokens[1];
					string birthdate = tokens[2];
					citizen = new Pet(name, birthdate);
					citizens.Add(citizen);
				}
			}
			string year = Console.ReadLine();
			foreach (var citizen in citizens)
			{
				if (citizen.Birthdate == null)
				{
					continue;
				}
				else if (citizen.Birthdate.Contains(year))
				{
					Console.WriteLine(citizen.Birthdate);
				}
			}
		}
	}
}
