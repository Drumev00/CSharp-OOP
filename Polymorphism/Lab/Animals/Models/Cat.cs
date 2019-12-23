using System;

namespace Animals.Models
{
	public class Cat : Animal
	{
		public Cat(string name, string food)
			:base(name, food)
		{
			
		}
		public override string ExplainSelf()
		{
			return $"I am {this.name} and my fovourite food is {this.favoriteFood}" +
				Environment.NewLine +
				"MEEOW";
		}
	}
}
