namespace P03_WildFarm.AbstractModels
{
	public abstract class Bird : Animal
	{
		protected double WingSize { get; set; }
		public Bird(string name, double weight, double wingSize) 
			: base(name, weight)
		{
			this.WingSize = wingSize;
		}
		public override string ToString()
		{
			return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
		}
	}
}
