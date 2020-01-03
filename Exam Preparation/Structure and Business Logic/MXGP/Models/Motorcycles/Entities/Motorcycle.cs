using System;

using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles.Entities
{
	public abstract class Motorcycle : IMotorcycle
	{
		private const int MIN_MODEL_SYMBOLS = 4;
		public Motorcycle(string model, int hp, double cubicCentimeters)
		{
			if (string.IsNullOrWhiteSpace(model) || model.Length < 4)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, model, MIN_MODEL_SYMBOLS));
			}
			this.Model = model;
			this.HorsePower = hp;
			this.CubicCentimeters = cubicCentimeters;
		}
		public string Model { get; }

		public int HorsePower { get; }

		public double CubicCentimeters { get; }

		public double CalculateRacePoints(int laps)
		{
			return (this.CubicCentimeters / HorsePower) * laps;
		}
	}
}
