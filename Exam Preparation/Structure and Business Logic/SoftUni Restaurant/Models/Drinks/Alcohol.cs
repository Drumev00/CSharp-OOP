namespace SoftUniRestaurant.Models.Drinks
{
	public class Alcohol : Drink
	{
		private const decimal INITIAL_PRICE = 3.50M;
		public Alcohol(string name, int servingSize, string brand, decimal price = INITIAL_PRICE)
			: base(name, servingSize, price, brand)
		{

		}
	}
}
