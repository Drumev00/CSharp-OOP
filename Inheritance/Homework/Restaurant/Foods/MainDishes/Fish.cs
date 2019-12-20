namespace Restaurant.Foods.MainDishes
{
	public class Fish : MainDish
	{
		public Fish(string name, decimal price)
			: base(name, price, FishGrams)
		{

		}
		private const double FishGrams = 22;
	}
}
