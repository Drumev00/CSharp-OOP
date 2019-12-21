using System;

namespace PersonsInfo
{
	public class Person
	{
		private string firstName;
		private string lastName;
		private int age;
		private decimal salary;

		public string FirstName
		{
			get => this.firstName;
			private set
			{
				ValidateName(value, "First");
				firstName = value;
			}
		}
		public string LastName
		{
			get => this.lastName;
			private set
			{
				ValidateName(value, "Last");
				lastName = value;
			}
		}
		public int Age
		{
			get => this.age;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Age cannot be zero or a negative integer!");
				}
				this.age = value;
			}
		}
		public decimal Salary
		{
			get => salary;
			private set
			{
				if (value < 460)
				{
					throw new ArgumentException("Salary cannot be less than 460 leva!");
				}
				this.salary = value;
			}
		}

		public Person(string firstName, string lastName, int age)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
		}

		public Person(string firstName, string lastName, int age, decimal salary)
			: this(firstName, lastName, age)
		{
			this.Salary = salary;
		}

		public override string ToString()
		{
			return $"{this.FirstName} {this.LastName} gets {this.Salary:F2} leva.";
		}

		private void ValidateName(string name, string nameType)
		{
			if (name.Length < 3)
			{
				throw new ArgumentException(nameType + " name cannot contain fewer than 3 symbols!");
			}
		}
	}
}
