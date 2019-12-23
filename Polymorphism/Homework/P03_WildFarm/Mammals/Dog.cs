using System;

using P03_WildFarm.AbstractModels;
using P03_WildFarm.Foods;

namespace P03_WildFarm.Mammals
{
	public class Dog : Mammal
	{
		public Dog(string name, double weight, string region) 
			: base(name, weight, region)
		{

		}
		public override void ProduceSound(Food food)
		{
			Console.WriteLine("Woof!");
			if (food is Meat meat)
			{
				Weight += meat.Quantity * 0.40;
				FoodEaten += food.Quantity;
			}
			else
			{
				base.ProduceSound(food);
			}
		}
	}
}
