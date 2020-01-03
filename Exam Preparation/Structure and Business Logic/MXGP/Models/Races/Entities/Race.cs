using System;
using System.Collections.Generic;
using System.Linq;

using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Races.Entities
{
	public class Race : IRace
	{
		private readonly List<IRider> riders;
		private const int MIN_NAME_CHARS = 5;
		private const int MIN_LAPS = 1;
		public Race(string name, int laps)
		{
			this.riders = new List<IRider>();
			if (string.IsNullOrWhiteSpace(name) || name.Length < 5)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, name, MIN_NAME_CHARS));
			}
			this.Name = name;
			if (laps < 1)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS));
			}
			this.Laps = laps;
		}
		public string Name { get; }

		public int Laps { get; }

		public IReadOnlyCollection<IRider> Riders => riders;

		public void AddRider(IRider rider)
		{
			if (rider is null)
			{
				throw new ArgumentException(ExceptionMessages.RiderInvalid);
			}
			else if (rider.Motorcycle == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
			}
			else if (riders.Any(r => r.Name == rider.Name))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
			}

			riders.Add(rider);
		}
	}
}
