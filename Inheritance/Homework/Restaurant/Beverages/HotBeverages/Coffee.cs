namespace Restaurant.Beverages.HotBeverages
{
	public class Coffee : HotBeverage
	{
		public Coffee(string name, double caffeine) 
			: base(name, CoffeePrice, CoffeeMillilitres)
		{
			this.Caffeine = caffeine;
		}
		private const double CoffeeMillilitres = 50;
		private const decimal CoffeePrice = 3.50M;
		public double Caffeine { get; set; }
	}
}
