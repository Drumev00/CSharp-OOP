using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
	public static class Runner
	{
		static List<Car> cars = new List<Car>();
		public static void Run()
		{
			int lines = int.Parse(Console.ReadLine());
			for (int i = 0; i < lines; i++)
			{
				string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string model = parameters[0];

				int engineSpeed = int.Parse(parameters[1]);
				int enginePower = int.Parse(parameters[2]);
				Engine engine = new Engine(engineSpeed, enginePower);

				int cargoWeight = int.Parse(parameters[3]);
				string cargoType = parameters[4];
				Cargo cargo = new Cargo(cargoWeight, cargoType);

				Tire[] tires = new Tire[(parameters.Length - 5) / 2];
				int index = 5;
				for (int j = 0; j < tires.Length; j++)
				{
					double pressure = double.Parse(parameters[index]);
					index++;
					int age = int.Parse(parameters[index]);
					index++;
					tires[j] = new Tire(age, pressure);
				}
				Car car = new Car(model, engine, cargo, tires);
				cars.Add(car);
			}

			string command = Console.ReadLine();
			List<string> neededCars = new List<string>();
			if (command == "fragile")
			{
				neededCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
				   .Select(x => x.Model)
				   .ToList();
			}
			else
			{
				neededCars = cars
					.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
					.Select(x => x.Model)
					.ToList();
			}
			Console.WriteLine(string.Join(Environment.NewLine, neededCars));
		}
	}
}
