using P07_FoodShortage.Interfaces;

namespace P07_FoodShortage.Models
{
	public class Citizen : IHuman, IBuyer
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Id { get; set; }
		public string Birthdate { get; set; }
		public int Food { get; set; }

		public Citizen(string name, int age, string id, string birthdate)
		{
			this.Name = name;
			this.Age = age;
			this.Id = id;
			this.Birthdate = birthdate;
		}
		public Citizen()
		{

		}

		public void BuyFood()
		{
			Food += 10;
		}
	}
}
