using System;
using System.Collections.Generic;
using System.Linq;

using P08_MilitaryElite.Interfaces;
using P08_MilitaryElite.Models;

namespace P08_MilitaryElite.Core
{
	public class Engine
	{
		private readonly List<ISoldier> army;

		public Engine()
		{
			army = new List<ISoldier>();
		}
		public void Run()
		{
			string command = string.Empty;

			while ((command = Console.ReadLine()) != "End")
			{
				string[] soldierArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string type = soldierArgs[0];
				string id = soldierArgs[1];
				string firstName = soldierArgs[2];
				string lastName = soldierArgs[3];
				decimal salary = decimal.Parse(soldierArgs[4]);
				if (type == "Private")
				{
					Private @private = new Private(id, firstName, lastName, salary);
					AddSoldier(@private);
				}
				else if (type == "LieutenantGeneral")
				{
					LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
					CreateLieutenant(soldierArgs, general);
					AddSoldier(general);
				}
				else if (type == "Engineer")
				{
					string corp = soldierArgs[5];
					IEngineer engineer = new Engineer(id, firstName, lastName, salary, corp);
					CreateEngineer(soldierArgs, engineer);
					AddSoldier(engineer);
				}
				else if (type == "Commando")
				{
					string corp = soldierArgs[5];
					ICommando commando = new Commando(id, firstName, lastName, salary, corp);
					CreateCommando(soldierArgs, commando);
					AddSoldier(commando);
				}
				else if (type == "Spy")
				{
					int codeNumber = (int)salary;
					ISpy spy = new Spy(id, firstName, lastName, codeNumber);
					AddSoldier(spy);
				}
			}
			PrintOutput();
		}

		private void PrintOutput()
		{
			foreach (var soldier in army)
			{
				Type type = soldier.GetType();
				object actual = Convert.ChangeType(soldier, type);
				Console.WriteLine(actual);
			}
		}

		private static void CreateCommando(string[] soldierArgs, ICommando commando)
		{
			string[] missionArgs = soldierArgs
			.Skip(6)
			.ToArray();
			for (int i = 0; i < missionArgs.Length; i += 2)
			{
				IMission mission = new Mission(missionArgs[i], missionArgs[i + 1]);
				commando.AddMission(mission);
			}
		}

		private static void CreateEngineer(string[] soldierArgs, IEngineer engineer)
		{
			string[] repairs = soldierArgs
			.Skip(6)
			.ToArray();
			for (int i = 0; i < repairs.Length; i += 2)
			{
				IRepair repair = new Repair(repairs[i], int.Parse(repairs[i + 1]));
				engineer.AddRepair(repair);
			}
		}

		private void CreateLieutenant(string[] soldierArgs, LieutenantGeneral general)
		{
			string[] troopIds = soldierArgs
			.Skip(5)
			.ToArray();
			for (int i = 0; i < troopIds.Length; i++)
			{
				ISoldier troop = army.First(x => x.Id == troopIds[i]);
				general.AddPrivate(troop);
			}
		}

		private void AddSoldier(ISoldier @private)
		{
			army.Add(@private);
		}
	}
}
