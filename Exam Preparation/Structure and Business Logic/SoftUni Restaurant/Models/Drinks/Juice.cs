namespace SoftUniRestaurant.Models.Drinks
{
	public class Juice : Drink
	{
		private const decimal INITIAL_PRICE = 1.80M;
		public Juice(string name, int servingSize, string brand, decimal price = INITIAL_PRICE) 
			: base(name, servingSize, price, brand)
		{

		}
	}
}
