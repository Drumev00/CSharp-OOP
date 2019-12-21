using System;

using P05_FootballTeamGenerator.Exceptions;

namespace P05_FootballTeamGenerator.Models
{
	public class Player
	{
		private string name;

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
		public Stat Stats { get; private set; }

		public Player(string name, Stat stats)
		{
			this.Name = name;
			this.Stats = stats;
		}

		public double OverallSkill()
		{
			return Math.Round(Stats.CalculateOverallStats(), 0);
		}
	}
}
