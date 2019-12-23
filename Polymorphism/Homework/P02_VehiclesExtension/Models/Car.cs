namespace P02_VehiclesExtension.Models
{
	public class Car : Vehicle
	{
		public Car(double quantity, double consumption, double capacity) 
			: base(quantity, consumption, capacity)
		{
			this.FuelConsumption += 0.9;
		}
	}
}
