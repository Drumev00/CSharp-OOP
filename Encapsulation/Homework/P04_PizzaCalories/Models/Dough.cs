using System;

using P04_PizzaCalories.Exceptions;

namespace P04_PizzaCalories.Models
{
	public class Dough
	{
		private const double WHITE_FLOUR = 1.5;
		private const double WHOLEGRAIN_FLOUR = 1.0;

		private const double CRISPY_TECHNIQUE = 0.9;
		private const double CHEWY_TECHNIQUE = 1.1;
		private const double HOMEMADE_TECHNIQUE = 1.0;

		string _flourType;
		private string flourType
		{
			get => _flourType;
			set
			{
				if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
				{
					throw new ArgumentException(ExceptionMessage.InvalidDoughException);
				}
				_flourType = value;
			}
		}

		string _bakingTechnique;
		private string bakingTechnique
		{
			get => _bakingTechnique;
			set
			{
				if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
				{
					throw new ArgumentException(ExceptionMessage.InvalidDoughException);
				}
				_bakingTechnique = value;
			}
		}

		int _weight;
		private int weight
		{
			get => _weight;
			set
			{
				if (value < 1 || value > 200)
				{
					throw new ArgumentException(ExceptionMessage.DoughWeightOutOfRangeException);
				}
				_weight = value;
			}
		}
		

		public Dough(string flour, string technique, int weight)
		{
			this.flourType = flour;
			this.bakingTechnique = technique;
			this.weight = weight;
		}

		public double CalculateCalories()
		{
			double calories = 0.0;

			if (flourType.ToLower() == "white" && bakingTechnique.ToLower() == "crispy")
			{
				calories = 2 * weight * WHITE_FLOUR * CRISPY_TECHNIQUE;
			}
			else if (flourType.ToLower() == "white" && bakingTechnique.ToLower() == "chewy")
			{
				calories = 2 * weight * WHITE_FLOUR * CHEWY_TECHNIQUE;
			}
			else if (flourType.ToLower() == "white" && bakingTechnique.ToLower() == "homemade")
			{
				calories = 2 * weight * WHITE_FLOUR * HOMEMADE_TECHNIQUE;
			}
			else if (flourType.ToLower() == "wholegrain" && bakingTechnique.ToLower() == "crispy")
			{
				calories = 2 * weight * WHOLEGRAIN_FLOUR * CRISPY_TECHNIQUE;
			}
			else if (flourType.ToLower() == "wholegrain" && bakingTechnique.ToLower() == "chewy")
			{
				calories = 2 * weight * WHOLEGRAIN_FLOUR * CHEWY_TECHNIQUE;
			}
			else if (flourType.ToLower() == "wholegrain" && bakingTechnique.ToLower() == "homemade")
			{
				calories = 2 * weight * WHOLEGRAIN_FLOUR * HOMEMADE_TECHNIQUE;
			}

			return calories;
		}
	}
}
