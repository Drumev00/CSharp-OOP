using System;
using System.Collections.Generic;

using P02_VehiclesExtension.Models;
using P02_VehiclesExtension.Exceptions;

namespace P02_VehiclesExtension.Core
{
	public class Engine
	{
		public void Run()
		{
			Car car = null;
			Truck truck = null;
			Bus bus = null;
			List<Vehicle> vehicles = new List<Vehicle>();
			for (int i = 0; i < 3; i++)
			{
				string[] vehicleArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string type = vehicleArgs[0];
				double fuelQuantity = double.Parse(vehicleArgs[1]);
				double consumption = double.Parse(vehicleArgs[2]);
				double capacity = double.Parse(vehicleArgs[3]);
				if (type == "Car")
				{
					car = new Car(fuelQuantity, consumption, capacity);
					vehicles.Add(car);
				}
				else if (type == "Truck")
				{
					truck = new Truck(fuelQuantity, consumption, capacity);
					vehicles.Add(truck);
				}
				else if (type == "Bus")
				{
					bus = new Bus(fuelQuantity, consumption, capacity);
					vehicles.Add(bus);
				}
			}
			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{
				try
				{
					string[] actions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
					string action = actions[0];
					string type = actions[1];
					double value = double.Parse(actions[2]);
					if (type == "Car")
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
					else if (type == "Truck")
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
					else if (type == "Bus")
					{
						if (action == "Drive")
						{
							Console.WriteLine(bus.Drive(value));
						}
						else if (action == "DriveEmpty")
						{
							Console.WriteLine(bus.DriveEmpty(value));
						}
						else if (action == "Refuel")
						{
							bus.Refuel(value);
						}
					}
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.Message);
				}
				catch (InvalidFuelArgument ifa)
				{
					Console.WriteLine(ifa.Message);
				}
			}
			foreach (var vehicle in vehicles)
			{
				Console.WriteLine(vehicle);
			}
		}
	}
}
