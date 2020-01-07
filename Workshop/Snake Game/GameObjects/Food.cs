using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
	public abstract class Food : Point
	{
		private Wall wall;
		private Random random;
		private char foodChar;
		public Food(Wall wall, char foodSymbol, int points) 
			: base(wall.LeftX, wall.TopY)
		{
			this.wall = wall;
			this.foodChar = foodSymbol;
			this.FoodPoints = points;
			this.random = new Random();
		}
		public int FoodPoints { get; private set; }
		public void SetRandomPosition(Queue<Point> snake)
		{
			this.LeftX = random.Next(2, wall.LeftX - 2);
			this.TopY = random.Next(2, wall.TopY - 2);

			bool isInSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
			while(isInSnake)
			{
				this.LeftX = random.Next(2, wall.LeftX - 2);
				this.TopY = random.Next(2, wall.TopY - 2);

				isInSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
			}

			Console.BackgroundColor = ConsoleColor.Red;
			Draw(foodChar);
			Console.BackgroundColor = ConsoleColor.White;
		}
		public bool IsFoodPoint(Point snake)
		{
			return snake.LeftX == this.LeftX &&
				   snake.TopY == this.TopY;
		}
	}
}
