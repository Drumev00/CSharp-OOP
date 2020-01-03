namespace SoftUniRestaurant.Models.Foods
{
	public class Dessert : Food
	{
		private const int INITIAL_SERVING_SIZE = 200;
		public Dessert(string name, decimal price, int servingSize = INITIAL_SERVING_SIZE) 
			: base(name, servingSize, price)
		{

		}
	}
}
