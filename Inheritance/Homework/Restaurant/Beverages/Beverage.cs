namespace Restaurant.Beverages
{
	public class Beverage : Product
	{
		public Beverage(string name, decimal price, double millilitres) 
			: base(name, price)
		{
			this.Millilitres = millilitres;
		}
		public double Millilitres { get; set; }
	}
}
