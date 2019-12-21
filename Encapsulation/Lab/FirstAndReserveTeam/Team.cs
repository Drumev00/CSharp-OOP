using System;
using System.Collections.Generic;

namespace PersonsInfo
{
	public class Team
	{
		private string name;
		private List<Person> firstTeam;
		private List<Person> reservedTeam;

		public IReadOnlyCollection<Person>  FirstTeam { get => firstTeam.AsReadOnly(); }
		public IReadOnlyCollection<Person> ReserveTeam { get => reservedTeam.AsReadOnly(); }
		public Team(string name)
		{
			this.name = name;
			this.firstTeam = new List<Person>();
			this.reservedTeam = new List<Person>();
		}

		public void AddPlayer(Person player)
		{
			if (player.Age < 40)
			{
				firstTeam.Add(player);
			}
			else
			{
				reservedTeam.Add(player);
			}
		}
	}
}
