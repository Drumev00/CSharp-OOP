using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
	public static class Runner
	{
		static List<Car> cars = new List<Car>();
		static List<Engine> engines = new List<Engine>();

		public static void Run()
		{
			int engineCount = int.Parse(Console.ReadLine());
			for (int i = 0; i < engineCount; i++)
			{
				string[] engineInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string model = engineInfo[0];
				int power = int.Parse(engineInfo[1]);

				if (engineInfo.Length == 3)
				{
					bool isDisplacement = int.TryParse(engineInfo[2], out int displacement);
					if (isDisplacement)
					{
						Engine engine = new Engine(model, power, displacement);
						engines.Add(engine);
					}
					else
					{
						string efficiency = engineInfo[2];
						Engine engine = new Engine(model, power, efficiency);
						engines.Add(engine);
					}

				}
				else if (engineInfo.Length == 4)
				{
					int displacement = int.Parse(engineInfo[2]);
					string efficiency = engineInfo[3];
					Engine engine = new Engine(model, power, displacement, efficiency);
					engines.Add(engine);
				}
				else
				{
					Engine engine = new Engine(model, power);
					engines.Add(engine);
				}
			}
			int carCount = int.Parse(Console.ReadLine());
			for (int i = 0; i < carCount; i++)
			{
				string[] carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string model = carInfo[0];
				string engineModel = carInfo[1];
				Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

				if (carInfo.Length == 3)
				{
					bool IsWeight = int.TryParse(carInfo[2], out int weight);
					if (IsWeight)
					{
						Car car = new Car(model, engine, weight);
						cars.Add(car);
					}
					else
					{
						string color = carInfo[2];
						Car car = new Car(model, engine, color);
						cars.Add(car);
					}
				}
				else if (carInfo.Length == 4)
				{
					int weight = int.Parse(carInfo[2]);
					string color = carInfo[3];
					Car car = new Car(model, engine, weight, color);
					cars.Add(car);
				}
				else
				{
					Car car = new Car(model, engine);
					cars.Add(car);
				}
			}

			foreach (var car in cars)
			{
				Console.WriteLine(car);
			}
		}
	}
}
