using System;

namespace P03_WildFarm.AbstractModels
{
	public abstract class Animal
	{
		protected string Name { get; set; }
		protected double Weight { get; set; }
		protected int FoodEaten { get; set; }
		public Animal(string name, double weight)
		{
			this.Name = name;
			this.Weight = weight;
		}
		public virtual void ProduceSound(Food food)
		{
			Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
		}
		public override string ToString()
		{
			return $"{GetType().Name} [{this.Name}, ";
		}
	}
}
