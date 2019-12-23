using System;

namespace P02_VehiclesExtension.Exceptions
{
	public class InvalidFuelArgument : Exception
	{
		private const string EXC_MESSAGE = "Fuel must be a positive number";
		public InvalidFuelArgument()
			:base(EXC_MESSAGE)
		{
		}

		public InvalidFuelArgument(string message) : base(message)
		{
		}
	}
}
