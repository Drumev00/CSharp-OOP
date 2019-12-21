using System;
using System.Collections.Generic;
using System.Linq;

using P05_FootballTeamGenerator.Exceptions;

namespace P05_FootballTeamGenerator.Models
{
	public class Team
	{
		private string name;
		public List<Player> Players { get; private set; }
		public string Name
		{
			get => this.name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessage.NameCannotBeEmptyException);
				}
				this.name = value;
			}
		}
		public string Rating()
		{
			return $"{this.Name} - {Players.Sum(p => p.OverallSkill())}";
		}

		public Team(string name)
		{
			this.Name = name;
			Players = new List<Player>();
		}

		public void AddPlayer(Player player)
		{
			Players.Add(player);
		}
		public void RemovePlayer(string name)
		{
			Player player = Players.FirstOrDefault(p => p.Name == name);
			if (player != null)
			{
				Players.Remove(player);
			}
			else if (player == null)
			{
				throw new InvalidOperationException(string.Format
					(ExceptionMessage.PlayerDoesntExistException, name, this.Name));
			}
		}
	}
}
