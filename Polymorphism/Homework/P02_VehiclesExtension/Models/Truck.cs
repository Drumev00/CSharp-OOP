namespace P02_VehiclesExtension.Models
{
	public class Truck : Vehicle
	{
		public Truck(double quantity, double consumption, double capacity) 
			: base(quantity, consumption, capacity)
		{
			this.FuelConsumption += 1.6;
		}
		public override void Refuel(double litres)
		{
			base.Refuel(litres);
			FuelQuantity -= litres * 0.05;
		}
	}
}
