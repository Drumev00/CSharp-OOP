using System;

using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles.Entities
{
	public class SpeedMotorcycle : Motorcycle
	{
		public SpeedMotorcycle(string model, int hp, double cubicCentimeters = 125) 
			: base(model, hp, cubicCentimeters)
		{
			if (hp < 50 || hp > 69)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, hp));
			}
		}
	}
}
