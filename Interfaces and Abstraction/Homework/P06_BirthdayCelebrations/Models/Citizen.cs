using P06_BirthdayCelebrations.Interfaces;

namespace P06_BirthdayCelebrations.Models
{
	public class Citizen : IIdentifiable, IBirthable
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Id { get; set; }
		public string Birthdate { get; set; }

		public Citizen(string name, int age, string id, string birthdate)
		{
			this.Name = name;
			this.Age = age;
			this.Id = id;
			this.Birthdate = birthdate;
		}
	}
}
