using System;

namespace P01_Vehicle.Models
{
	public class Car : Vehicle
	{
		public Car(double quantity, double consumption) 
			: base(quantity, consumption)
		{
			base.FuelConsumption += 0.9;
		}
	}
}
