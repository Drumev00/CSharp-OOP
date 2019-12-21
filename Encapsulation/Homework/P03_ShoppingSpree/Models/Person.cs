using System;
using System.Collections.Generic;

using P03_ShoppingSpree.Exceptions;

namespace P03_ShoppingSpree.Models
{
	public class Person
	{
		private string name;
		private decimal money;
		private List<Product> bag;

		public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			bag = new List<Product>();
		}

		public string Name
		{
			get => this.name;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessage.InvalidNameException);
				}
				this.name = value;
			}
		}
		public decimal Money
		{
			get => this.money;
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException(ExceptionMessage.MoneyCannotBeNegativeException);
				}
				this.money = value;
			}
		}

		public void BuyProduct(Product product)
		{
			decimal moneyLeft = Money - product.Price;
			if (moneyLeft < 0 )
			{
				throw new InvalidOperationException(string.Format
					(ExceptionMessage.NotEnoughMoneyException, this.Name, product.Name));
			}
			else
			{
				Console.WriteLine($"{this.Name} bought {product.Name}");
				bag.Add(product);
			}
			Money = moneyLeft;
		}

		public override string ToString()
		{
			if (this.bag.Count == 0)
			{
				return $"{this.Name} - Nothing bought";
			}
			return $"{this.Name} - {string.Join(", ", bag)}";
		}
	}
}
