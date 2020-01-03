namespace SoftUniRestaurant.Models.Tables
{
	public class OutsideTable : Table
	{
		private const decimal INITIAL_PRICE_PER_PERSON = 3.50M;
		public OutsideTable(int tableNumber, int capacity, decimal pricePerPerson = INITIAL_PRICE_PER_PERSON) 
			: base(tableNumber, capacity, pricePerPerson)
		{

		}
	}
}
