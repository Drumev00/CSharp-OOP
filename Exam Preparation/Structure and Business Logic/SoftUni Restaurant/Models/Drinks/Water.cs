namespace SoftUniRestaurant.Models.Drinks
{
	public class Water : Drink
	{
		private const decimal INITIAL_PRICE = 1.50M;
		public Water(string name, int servingSize, string brand, decimal price = INITIAL_PRICE) 
			: base(name, servingSize, price, brand)
		{

		}
	}
}
