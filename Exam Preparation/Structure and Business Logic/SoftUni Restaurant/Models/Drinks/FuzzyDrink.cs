namespace SoftUniRestaurant.Models.Drinks
{
	public class FuzzyDrink : Drink
	{
		private const decimal INITIAL_PRICE = 2.50M;
		public FuzzyDrink(string name, int servingSize, string brand, decimal price = INITIAL_PRICE) 
			: base(name, servingSize, price, brand)
		{

		}
	}
}
