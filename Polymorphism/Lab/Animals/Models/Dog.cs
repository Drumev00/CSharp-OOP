using System;

namespace Animals.Models
{
	public class Dog : Animal
	{
		public Dog(string name, string food) 
			: base(name, food)
		{

		}
		public override string ExplainSelf()
		{
			return $"I am {this.name} and my fovourite food is {this.favoriteFood}" +
				Environment.NewLine +
				"DJAAF";
		}
	}
}
