using System;

using P01_Vehicle.Models;

namespace P01_Vehicle.Core
{
	public class Engine
	{
		public void Run()
		{
			string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));

			string[] truckArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{
				string[] vehicleArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string action = vehicleArgs[0];
				string vehicle = vehicleArgs[1];
				double value = double.Parse(vehicleArgs[2]);
				if (vehicle == "Car")
				{
					if (action == "Drive")
					{
						Console.WriteLine(car.Drive(value));
					}
					else if (action == "Refuel")
					{
						car.Refuel(value);
					}
				}
				else if (vehicle == "Truck")
				{
					if (action == "Drive")
					{
						Console.WriteLine(truck.Drive(value));
					}
					else if (action == "Refuel")
					{
						truck.Refuel(value);
					}
				}
			}
			Console.WriteLine(car + Environment.NewLine + truck);
		}
	}
}
