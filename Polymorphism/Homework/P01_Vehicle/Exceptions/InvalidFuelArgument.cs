using System;

namespace P01_Vehicle.Exceptions
{
	public class InvalidFuelArgument : Exception
	{
		private const string EXC_MESSAGE = "Fuel consumption/quantity cannot be zero or negative";
		public InvalidFuelArgument()
			:base(EXC_MESSAGE)
		{
		}

		public InvalidFuelArgument(string message) : base(message)
		{
		}
	}
}
