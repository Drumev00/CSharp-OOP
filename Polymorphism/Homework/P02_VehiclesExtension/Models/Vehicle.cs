using System;

using P02_VehiclesExtension.Exceptions;

namespace P02_VehiclesExtension.Models
{
	public abstract class Vehicle
	{
		protected double FuelQuantity { get; set; }
			
		protected double FuelConsumption { get; set; }
		protected double TankCapacity { get; set; }

		protected Vehicle(double quantity, double consumption, double capacity)
		{
			this.FuelQuantity = quantity;
			this.FuelConsumption = consumption;
			if (FuelQuantity > capacity)
			{
				FuelQuantity = 0;
			}
			this.TankCapacity = capacity;
		}

		public virtual string Drive(double distance)
		{
			double fuelburnt = distance * FuelConsumption;
			if (fuelburnt <= FuelQuantity)
			{
				FuelQuantity -= fuelburnt;
				return $"{GetType().Name} travelled {distance} km";
			}
			else
			{
				return $"{GetType().Name} needs refueling";
			}
		}

		public virtual void Refuel(double litres)
		{
			if (litres <= 0)
			{
				throw new InvalidFuelArgument();
			}
			else if (litres + FuelQuantity > this.TankCapacity)
			{
				throw new ArgumentException($"Cannot fit {litres} fuel in the tank");
			}
			FuelQuantity += litres;
		}
		public override string ToString()
		{
			return $"{GetType().Name}: {this.FuelQuantity:F2}";
		}
	}
}
