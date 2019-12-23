namespace P03_WildFarm.AbstractModels
{
	public abstract class Mammal : Animal
	{
		protected string LivingRegion { get; set; }
		public Mammal(string name, double weight, string region) 
			: base(name, weight)
		{
			this.LivingRegion = region;
		}
		public override string ToString()
		{
			return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
		}
	}
}
