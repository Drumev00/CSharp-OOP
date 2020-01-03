namespace SoftUniRestaurant.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Tables;

    public class RestaurantController
    {
		private List<Food> menu;
		private List<Drink> drinks;
		private List<Table> tables;
		public RestaurantController()
		{
			menu = new List<Food>();
			drinks = new List<Drink>();
			tables = new List<Table>();
		}
        public string AddFood(string type, string name, decimal price)
        {
			Food food = null;
			if (type == "Dessert")
			{
				food = new Dessert(name, price);
			}
			else if (type == "MainCourse")
			{
				food = new MainCourse(name, price);
			}
			else if (type == "Salad")
			{
				food = new Salad(name, price);
			}
			else if (type == "Soup")
			{
				food = new Soup(name, price);
			}
			menu.Add(food);

			return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:F2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
			Drink drink = null;
			if (type == "Alcohol")
			{
				drink = new Alcohol(name, servingSize, brand);
			}
			else if (type == "FuzzyDrink")
			{
				drink = new FuzzyDrink(name, servingSize, brand);
			}
			else if (type == "Juice")
			{
				drink = new Juice(name, servingSize, brand);
			}
			else if (type == "Water")
			{
				drink = new Water(name, servingSize, brand);
			}
			drinks.Add(drink);

			return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
		}

		public string AddTable(string type, int tableNumber, int capacity)
        {
			Table table = null;
			if (type == "InsideTable")
			{
				table = new InsideTable(tableNumber, capacity);
			}
			else if (type == "OutsideTable")
			{
				table = new OutsideTable(tableNumber, capacity);
			}
			tables.Add(table);

			return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
			string message = string.Empty;

			Table table = tables.FirstOrDefault(t => !t.IsReserved && t.NumberOfPeople <= numberOfPeople);
			if (table == null)
			{
				message = $"No available table for {numberOfPeople} people";
			}
			else
			{
				table.Reserve(numberOfPeople);
				message = $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
			}

			return message;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
			Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
			if (table == null)
			{
				return $"Could not find table with {tableNumber}";
			}
			Food food = menu.FirstOrDefault(f => f.Name == foodName);
			if (food == null)
			{
				return $"No {foodName} in the menu";
			}

			table.OrderFood(food);
			return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
			Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
			if (table == null)
			{
				return $"Could not find table with {tableNumber}";
			}
			Drink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
			if (drink == null)
			{
				return $"There is no {drinkName} {drinkBrand} available";
			}

			table.OrderDrink(drink);
			return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
			Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
			decimal wholeBill = table.GetBill();
			table.Clear();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Table: {tableNumber}")
				.AppendLine($"Bill: {wholeBill:F2}");

			return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
			StringBuilder sb = new StringBuilder();

			foreach (var table in tables)
			{
				if (!table.IsReserved)
				{
					sb.AppendLine(table.GetFreeTableInfo());
				}
			}

			return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
			StringBuilder sb = new StringBuilder();

			foreach (var table in tables)
			{
				if (!table.IsReserved)
				{
					sb.AppendLine(table.GetOccupiedTableInfo());
				}
			}

			return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
			decimal moneyForReservingTable = tables.Sum(x => x.Price);
			decimal moneyByOrderingFoods = menu.Sum(x => x.Price);
			decimal moneyByOrderingDrinks = drinks.Sum(x => x.Price);

			decimal totalIncome = moneyForReservingTable + moneyByOrderingFoods + moneyByOrderingDrinks;

			return $"Total income: {totalIncome:f2}lv";
        }
    }
}
