namespace SoftUniRestaurant.Models.Tables
{
	public class InsideTable : Table
	{
		private const decimal INITIAL_PRICE_PER_PERSON = 2.50M;
		public InsideTable(int tableNumber, int capacity, decimal pricePerPerson = INITIAL_PRICE_PER_PERSON) 
			: base(tableNumber, capacity, pricePerPerson)
		{

		}
	}
}
