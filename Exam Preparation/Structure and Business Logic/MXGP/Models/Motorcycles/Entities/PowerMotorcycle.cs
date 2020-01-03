using System;

using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles.Entities
{
	public class PowerMotorcycle : Motorcycle
	{
		public PowerMotorcycle(string model, int hp, double cubicCentimeters = 450)
			: base(model, hp, cubicCentimeters)
		{
			if (hp < 70 || hp > 100)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, hp));
			}
		}
	}
}
