using System;
using System.Collections.Generic;

using P03_WildFarm.AbstractModels;
using P03_WildFarm.Birds;
using P03_WildFarm.Foods;
using P03_WildFarm.Mammals;
using P03_WildFarm.Mammals.Felines;

namespace P03_WildFarm.Core
{
	public class Engine
	{
		static List<Animal> animals;
		public Engine()
		{
			animals = new List<Animal>();
		}
		public void Run()
		{
			string commandArgs = string.Empty;
			while((commandArgs = Console.ReadLine()) != "End")
			{
				Animal animal = null;
				string[] animalInfo = commandArgs.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string animalType = animalInfo[0];
				animal = CreateAnimal(animalType, animalInfo);
				animals.Add(animal);

				Food food = null;
				string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string foodType = foodInfo[0];
				food = CreateFood(foodType, foodInfo);

				animal.ProduceSound(food);
			}
			PrintOutput();
		}
		private Animal CreateAnimal(string type, string[] info)
		{
			Animal animal = null;
			if (type == "Hen")
			{
				double wingSize = double.Parse(info[3]);
				animal = new Hen(info[1], double.Parse(info[2]), wingSize);
			}
			else if (type == "Owl")
			{
				double wingSize = double.Parse(info[3]);
				animal = new Owl(info[1], double.Parse(info[2]), wingSize);
			}
			else if (type == "Mouse")
			{
				string region = info[3];
				animal = new Mouse(info[1], double.Parse(info[2]), region);
			}
			else if (type == "Dog")
			{
				string region = info[3];
				animal = new Dog(info[1], double.Parse(info[2]), region);
			}
			else if (type == "Cat")
			{
				string region = info[3];
				string breed = info[4];
				animal = new Cat(info[1], double.Parse(info[2]), region, breed);
			}
			else if (type == "Tiger")
			{
				string region = info[3];
				string breed = info[4];
				animal = new Tiger(info[1], double.Parse(info[2]), region, breed);
			}

			return animal;
		}
		private Food CreateFood(string type, string[] info)
		{
			Food food = null;
			int quantity = int.Parse(info[1]);
			if (type == "Vegetable")
			{
				food = new Vegetable(quantity);
			}
			else if (type == "Seeds")
			{
				food = new Seeds(quantity);
			}
			else if (type == "Meat")
			{
				food = new Meat(quantity);
			}
			else if (type == "Fruit")
			{
				food = new Fruit(quantity);
			}

			return food;
		}
		private void PrintOutput()
		{
			foreach (var animal in animals)
			{
				Type type = animal.GetType();
				object actual = Convert.ChangeType(animal, type);
				Console.WriteLine(actual);
			}
		}
	}
}
