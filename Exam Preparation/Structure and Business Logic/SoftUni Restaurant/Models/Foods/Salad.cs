namespace SoftUniRestaurant.Models.Foods
{
	public class Salad : Food
	{
		private const int INITAL_SERVING_SIZE = 300;
		public Salad(string name, decimal price, int servingSize = INITAL_SERVING_SIZE) 
			: base(name, servingSize, price)
		{

		}
	}
}
