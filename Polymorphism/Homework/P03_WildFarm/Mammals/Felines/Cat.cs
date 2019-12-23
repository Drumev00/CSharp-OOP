using System;

using P03_WildFarm.AbstractModels;
using P03_WildFarm.Foods;

namespace P03_WildFarm.Mammals.Felines
{
	public class Cat : Feline
	{
		public Cat(string name, double weight, string region, string breed) 
			: base(name, weight, region, breed)
		{

		}
		public override void ProduceSound(Food food)
		{
			Console.WriteLine("Meow");
			if (food is Vegetable veg)
			{
				Weight += veg.Quantity * 0.30;
				FoodEaten += food.Quantity;
			}
			else if (food is Meat meat)
			{
				Weight += meat.Quantity * 0.30;
				FoodEaten += food.Quantity;
			}
			else
			{
				base.ProduceSound(food);
			}
		}
	}
}
