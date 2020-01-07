using System;
using System.Collections.Generic;
using System.Linq;

using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
	public class Snake
	{
		private Wall wall;
		private Food[] food;
		private int RandomFoodNumber => new Random().Next(0, food.Length);
		private int foodIndex;

		private int nextLeftX;
		private int nextTopY;

		private const char snakeSymbol = '\u25CF';
		private const char emptySpace = ' ';
		private Queue<Point> snakePositions;
		public Snake(Wall wall)
		{
			this.wall = wall;
			this.snakePositions = new Queue<Point>();
			this.food = new Food[3];
			this.foodIndex = RandomFoodNumber;
			this.GetFoods();
			this.CreateSnake();
		}

		private void CreateSnake()
		{
			for (int i = 1; i <= 6; i++)
			{
				Point point = new Point(2, i);
				snakePositions.Enqueue(point);
			}
		}
		private void GetFoods()
		{
			food[0] = new FoodAsterisk(this.wall);
			food[1] = new FoodDollar(this.wall);
			food[2] = new FoodHash(this.wall);
		}
		public bool IsMoving(Point direction)
		{
			Point snakeHead = snakePositions.Last();
			GetNextPoint(direction, snakeHead);

			bool IsPointOfSnake = snakePositions.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);
			if (IsPointOfSnake)
			{
				return false;
			}

			Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);
			if (this.wall.IsPointOfWall(snakeNewHead))
			{
				return false;
			}
			this.snakePositions.Enqueue(snakeNewHead);
			snakeNewHead.Draw(snakeSymbol);

			if (food[foodIndex].IsFoodPoint(snakeNewHead))
			{
				Eat(direction, snakeHead);
			}
			Point snakeTail = snakePositions.Dequeue();
			snakeTail.Draw(emptySpace);
			return true;

		}
		private void GetNextPoint(Point direction, Point snakeHead)
		{
			this.nextLeftX = direction.LeftX + snakeHead.LeftX;
			this.nextTopY = direction.TopY + snakeHead.TopY;
		}
		private void Eat(Point direction, Point snakeHead)
		{
			int length = food[foodIndex].FoodPoints;
			for (int i = 0; i < length; i++)
			{
				snakePositions.Enqueue(new Point(nextLeftX, nextTopY));
				GetNextPoint(direction, snakeHead);
			}

			this.foodIndex = this.RandomFoodNumber;
			this.food[foodIndex].SetRandomPosition(snakePositions);
		}
	}
}
