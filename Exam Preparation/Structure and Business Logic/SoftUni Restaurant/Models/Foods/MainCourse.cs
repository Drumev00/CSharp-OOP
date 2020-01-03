namespace SoftUniRestaurant.Models.Foods
{
	public class MainCourse : Food
	{
		private const int INITIAL_SERVING_SIZE = 500;
		public MainCourse(string name, decimal price, int servingSize = INITIAL_SERVING_SIZE) 
			: base(name, servingSize, price)
		{

		}
	}
}
