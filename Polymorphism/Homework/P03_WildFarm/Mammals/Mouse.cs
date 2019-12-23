using System;

using P03_WildFarm.AbstractModels;
using P03_WildFarm.Foods;

namespace P03_WildFarm.Mammals
{
	public class Mouse : Mammal
	{
		public Mouse(string name, double weight, string region) 
			: base(name, weight, region)
		{

		}
		public override void ProduceSound(Food food)
		{
			Console.WriteLine("Squeak");
			if (food is Vegetable veg)
			{
				Weight += veg.Quantity * 0.10;
				FoodEaten += food.Quantity;
			}
			else if (food is Fruit fruit)
			{
				Weight += fruit.Quantity * 0.10;
				FoodEaten += food.Quantity;
			}
			else
			{
				base.ProduceSound(food);
			}
		}
	}
}
