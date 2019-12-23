using P01_Vehicle.Exceptions;

namespace P01_Vehicle.Models
{
	public abstract class Vehicle
	{
		private double fuelQuantity;
		private double fuelConsumption;
		protected double FuelQuantity {
			get => this.fuelQuantity;
			set
			{
				if (value <= 0)
				{
					throw new InvalidFuelArgument();
				}
				this.fuelQuantity = value;
			}
		}
		protected double FuelConsumption {
			get => this.fuelConsumption;
			set
			{
				if (value <= 0)
				{
					throw new InvalidFuelArgument();
				}
				this.fuelConsumption = value;
			}
		}
		protected Vehicle(double quantity, double consumption)
		{
			this.FuelQuantity = quantity;
			this.FuelConsumption = consumption;
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
			FuelQuantity += litres;
		}
		public override string ToString()
		{
			return $"{GetType().Name}: {this.FuelQuantity:F2}";
		}
	}
}
