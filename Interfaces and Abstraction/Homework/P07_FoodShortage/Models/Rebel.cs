using P07_FoodShortage.Interfaces;

namespace P07_FoodShortage.Models
{
	public class Rebel : IBuyer
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Group { get; set; }
		public int Food { get; set; }
		public Rebel(string name, int age, string group)
		{
			this.Name = name;
			this.Age = age;
			this.Group = group;
		}
		public void BuyFood()
		{
			Food += 5;
		}
	}
}
