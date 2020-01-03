namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
		int TableNumber { get; }
		int Capacity { get; }
		int NumberOfPeople { get; }
		decimal PricePerPerson { get; }
		bool IsReserved { get; }
		decimal Price { get; }
	}
}
