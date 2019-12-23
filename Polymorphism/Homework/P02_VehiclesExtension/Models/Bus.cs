namespace P02_VehiclesExtension.Models
{
	public class Bus : Vehicle
	{
		public Bus(double quantity, double consumption, double capacity) 
			: base(quantity, consumption, capacity)
		{
			
		}
		public override string Drive(double distance)
		{
			FuelConsumption += 1.4;

			return base.Drive(distance);
		}
		public string DriveEmpty(double distance)
		{
			return base.Drive(distance);
		}
	}
}
