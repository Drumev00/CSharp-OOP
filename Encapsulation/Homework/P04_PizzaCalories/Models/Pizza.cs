using System;
using System.Collections.Generic;
using System.Linq;

using P04_PizzaCalories.Exceptions;

namespace P04_PizzaCalories.Models
{
	public class Pizza
	{
		private string name;
		public Dough Dough { get; set; }
		public string Name
		{
			get => this.name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
				{
					throw new ArgumentException(ExceptionMessage.PizzaNameOutOfRangeException);
				}
				this.name = value;
			}
		}
		public List<Topping> Toppings { get; private set; }

		public int ToppingCount
		{
			get
			{
				return Toppings.Count;
			}
		}

		public Pizza(string name, Dough dough)
		{
			this.Name = name;
			this.Dough = dough;
			this.Toppings = new List<Topping>();
		}

		public void AddTopping(Topping topping)
		{
			if (Toppings.Count > 10)
			{
				throw new InvalidOperationException(ExceptionMessage.PizzaToppingsOutOfRangeException);
			}
			Toppings.Add(topping);
		}
		public double CalculateAllCalories()
		{
			double toppingCalories = Toppings.Sum(t => t.CalculateCalories());
			double doughCalories = Dough.CalculateCalories();

			return toppingCalories + doughCalories;
		}
		public override string ToString()
		{
			return $"{this.Name} - {CalculateAllCalories():F2} Calories.";
		}
	}
}
