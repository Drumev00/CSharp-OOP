using P06_BirthdayCelebrations.Interfaces;

namespace P06_BirthdayCelebrations.Models
{
	public class Pet : IBirthable
	{
		public string Name { get; }
		public string Birthdate { get; }
		public Pet(string name, string birthdate)
		{
			this.Name = name;
			this.Birthdate = birthdate;
		}
	}
}
