namespace P01_Vehicle.Models
{
	public class Truck : Vehicle
	{
		public Truck(double quantity, double consumption) 
			: base(quantity, consumption)
		{
			base.FuelConsumption += 1.6;
		}
		public override void Refuel(double litres)
		{
			FuelQuantity += litres * 95 / 100;
		}
	}
}
