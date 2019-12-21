using System;

using P03_ShoppingSpree.Exceptions;

namespace P03_ShoppingSpree.Models
{
	public class Product
	{
		private string name;

		public Product(string name, decimal price)
		{
			this.Name = name;
			this.Price = price;
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
		public decimal Price { get; private set; }

		public override string ToString()
		{
			return $"{this.Name}";
		}
	}
}
