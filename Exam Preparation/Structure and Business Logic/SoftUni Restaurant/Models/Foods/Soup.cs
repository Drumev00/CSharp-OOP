namespace SoftUniRestaurant.Models.Foods
{
	public class Soup : Food
	{
		private const int INITIAL_SERVING_SIZE = 245;
		public Soup(string name, decimal price, int servingSize = INITIAL_SERVING_SIZE) 
			: base(name, servingSize, price)
		{

		}
	}
}
