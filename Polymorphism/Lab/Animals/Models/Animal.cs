namespace Animals.Models
{
	public abstract class Animal
	{
		protected string name;
		protected string favoriteFood;

		public Animal(string name, string food)
		{
			this.name = name;
			this.favoriteFood = food;
		}
		public virtual string ExplainSelf()
		{
			return "Im just an animal";
		}
	}
}
