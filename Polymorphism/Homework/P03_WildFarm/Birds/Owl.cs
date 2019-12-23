using System;

using P03_WildFarm.AbstractModels;
using P03_WildFarm.Foods;

namespace P03_WildFarm.Birds
{
	public class Owl : Bird
	{
		public Owl(string name, double weight, double wingSize) 
			: base(name, weight, wingSize)
		{

		}
		public override void ProduceSound(Food food)
		{
			Console.WriteLine("Hoot Hoot");
			if (food is Meat meat)
			{
				Weight += meat.Quantity * 0.25;
				FoodEaten += food.Quantity;
			}
			else
			{
				base.ProduceSound(food);
			}
		}
	}
}
