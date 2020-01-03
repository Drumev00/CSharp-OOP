using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables
{
	
	public abstract class Table : ITable
	{
		private readonly List<IFood> foodOrders;
		private readonly List<IDrink> drinkOrders;
		private int capacity;
		private int numberOfPeople;
		public Table(int tableNumber, int capacity, decimal pricePerPerson)
		{
			foodOrders = new List<IFood>();
			drinkOrders = new List<IDrink>();
			this.TableNumber = tableNumber;
			this.Capacity = capacity;
			this.PricePerPerson = pricePerPerson;
		}
		protected IReadOnlyCollection<IFood> FoodOrders => foodOrders.AsReadOnly();

		protected IReadOnlyCollection<IDrink> DrinkOrders => drinkOrders.AsReadOnly();

		public int TableNumber { get; private set; }

		public int Capacity
		{
			get => this.capacity;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException("Capacity has to be greater than 0");
				}
				this.capacity = value;
			}
		}

		public int NumberOfPeople
		{
			get => this.numberOfPeople;
			protected set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Cannot place zero or less people!");
				}
				this.numberOfPeople = value;
			}
		}

		public decimal PricePerPerson { get; private set; }

		public bool IsReserved { get; private set; }

		public decimal Price => PricePerPerson * NumberOfPeople;
		public void Reserve(int numberOfPeople)
		{
			this.NumberOfPeople = numberOfPeople;
			this.IsReserved = true;
		}
		public void OrderFood(IFood food)
		{
			if (food != null)
			{
				this.foodOrders.Add(food);
			}
		}
		public void OrderDrink(IDrink drink)
		{
			if (drink != null)
			{
				this.drinkOrders.Add(drink);
			}
		}
		public decimal GetBill()
		{
			decimal foodPrices = this.foodOrders.Sum(x => x.Price);
			decimal drinkPrices = this.drinkOrders.Sum(x => x.Price);

			return foodPrices + drinkPrices;
		}

		public void Clear()
		{
			this.foodOrders.Clear();
			this.drinkOrders.Clear();

			this.NumberOfPeople = 0;
			this.IsReserved = false;
		}
		public string GetFreeTableInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Table: {this.TableNumber}")
				.AppendLine($"Type: {this.GetType().Name}")
				.AppendLine($"Capacity: {this.Capacity}")
				.AppendLine($"Price per Person: {this.PricePerPerson}");

			return sb.ToString().TrimEnd();
		}
		public string GetOccupiedTableInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Table: {this.TableNumber}")
				.AppendLine($"Type: {this.GetType().Name}")
				.AppendLine($"Number of people: {this.NumberOfPeople}");
			if (this.FoodOrders.Count == 0)
			{
				sb.AppendLine("Food orders: None");
			}
			if (this.FoodOrders.Count > 0)
			{
				sb.AppendLine($"Food orders: {this.FoodOrders.Count}");
				foreach (var food in FoodOrders)
				{
					sb.AppendLine(food.ToString());
				}
			}
			if (this.DrinkOrders.Count == 0)
			{
				sb.AppendLine("Drink orders: None");
			}
			if (this.DrinkOrders.Count > 0)
			{
				sb.AppendLine($"Drink orders: {this.DrinkOrders.Count}");
				foreach (var drink in DrinkOrders)
				{
					sb.AppendLine(drink.ToString());
				}
			}

			return sb.ToString().TrimEnd();
		}
	}
}
