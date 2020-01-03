using System;

using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Riders.Entities
{
	public class Rider : IRider
	{
		private const int MIN_NAME_CHARS = 5;
		private IMotorcycle motorcycle;
		private int numberOfWins;
		private bool canParticipate;
		public Rider(string name)
		{
			if (string.IsNullOrWhiteSpace(name) || name.Length < 5)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, name, MIN_NAME_CHARS));
			}
			this.Name = name;
		}
		public string Name { get; }

		public IMotorcycle Motorcycle => motorcycle;

		public int NumberOfWins => numberOfWins;

		public bool CanParticipate => canParticipate;

		public void AddMotorcycle(IMotorcycle motorcycle)
		{
			if (motorcycle == null)
			{
				canParticipate = false;
				throw new ArgumentException(ExceptionMessages.MotorcycleInvalid);
			}
			this.motorcycle = motorcycle;
		}

		public void WinRace()
		{
			numberOfWins++;
		}
	}
}
