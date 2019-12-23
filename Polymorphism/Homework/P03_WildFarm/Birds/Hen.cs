using System;

using P03_WildFarm.AbstractModels;

namespace P03_WildFarm.Birds
{
	public class Hen : Bird
	{
		public Hen(string name, double weight, double wingSize) 
			: base(name, weight, wingSize)
		{

		}
		public override void ProduceSound(Food food)
		{
			Console.WriteLine("Cluck");
			Weight += food.Quantity * 0.35;
			FoodEaten += food.Quantity;
		}
		
	}
}
