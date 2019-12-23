namespace P03_WildFarm.AbstractModels
{
	public abstract class Feline : Mammal
	{
		protected string Breed { get; set; }
		public Feline(string name, double weight, string region, string breed) 
			: base(name, weight, region)
		{
			this.Breed = breed;
		}
		public override string ToString()
		{
			return $"{ GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
		}
	}
}
