using System;

using P04_PizzaCalories.Exceptions;

namespace P04_PizzaCalories.Models
{
	public class Topping
	{
		private const double MEAT_MODIFIER = 1.2;
		private const double VEGGIES_MODIFIER = 0.8;
		private const double CHEESE_MODIFIER = 1.1;
		private const double SAUCE_MODIFIER = 0.9;

		string _type;
		private string type
		{
			get => _type;
			set
			{
				if (value.ToLower() != "meat"
					&& value.ToLower() != "veggies"
					&& value.ToLower() != "cheese"
					&& value.ToLower() != "sauce")
				{
					throw new ArgumentException(string.Format(ExceptionMessage.InvalidToppingException, value));
				}
				this._type = value;
			}
		}

		int _weight;
		private int weight
		{
			get => _weight;
			set
			{
				if (value < 1 || value > 50)
				{
					throw new ArgumentException(string.Format(ExceptionMessage.ToppingOutOfRangeException, type));
				}
				this._weight = value;
			}
		}

		public Topping(string type, int weight)
		{
			this.type = type;
			this.weight = weight;
		}

		public double CalculateCalories()
		{
			double calories = 0.0;
			if (type.ToLower() == "meat")
			{
				calories = 2 * weight * MEAT_MODIFIER;
			}
			else if (type.ToLower() == "veggies")
			{
				calories = 2 * weight * VEGGIES_MODIFIER;
			}
			else if (type.ToLower() == "cheese")
			{
				calories = 2 * weight * CHEESE_MODIFIER;
			}
			else if (type.ToLower() == "sauce")
			{
				calories = 2 * weight * SAUCE_MODIFIER;
			}

			return calories;
		}
	}
}
