using System;

using P03_WildFarm.AbstractModels;
using P03_WildFarm.Foods;

namespace P03_WildFarm.Mammals.Felines
{
	public class Tiger : Feline
	{
		public Tiger(string name, double weight, string region, string breed) 
			: base(name, weight, region, breed)
		{

		}
		public override void ProduceSound(Food food)
		{
			Console.WriteLine("ROAR!!!");
			if (food is Meat meat)
			{
				Weight += meat.Quantity * 1.00;
				FoodEaten += food.Quantity;
			}
			else
			{
				base.ProduceSound(food);
			}
		}
	}
}
