using System;

using P05_FootballTeamGenerator.Exceptions;

namespace P05_FootballTeamGenerator.Models
{
	public class Stat
	{
		private double endurance;
		private double sprint;
		private double dribble;
		private double passing;
		private double shooting;

		public Stat(double endurance, double sprint, double dribble, double passing, double shooting)
		{
			this.Endurance = endurance;
			this.Sprint = sprint;
			this.Dribble = dribble;
			this.Passing = passing;
			this.Shooting = shooting;
		}

		public double Endurance
		{
			get => this.endurance;
			private set
			{
				StatValidation(value, nameof(this.Endurance));
				this.endurance = value;
			}
		}
		public double Sprint
		{
			get => this.sprint;
			private set
			{
				StatValidation(value, nameof(this.Sprint));
				this.sprint = value;
			}
		}
		public double Dribble
		{
			get => this.dribble;
			private set
			{
				StatValidation(value, nameof(this.Dribble));
				this.dribble = value;
			}
		}
		public double Passing
		{
			get => this.passing;
			private set
			{
				StatValidation(value, nameof(this.Passing));
				this.passing = value;
			}
		}
		public double Shooting
		{
			get => this.shooting;
			private set
			{
				StatValidation(value, nameof(this.Shooting));
				this.shooting = value;
			}
		}

		private void StatValidation(double value, string whichOne)
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentException(string.Format(ExceptionMessage.StatOutOfRangeException, whichOne));
			}
		}

		public double CalculateOverallStats()
		{
			double result = (this.Endurance + this.Sprint
				+ this.Dribble + this.Passing
				+ this.Shooting) / 5;

			return result;
		}
	}
}
