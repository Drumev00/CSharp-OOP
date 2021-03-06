﻿namespace SimpleSnake.GameObjects
{
	public class Wall : Point
	{
		private const char WALL_SYMBOL = '\u25A0';
		public Wall(int leftX, int topY) 
			: base(leftX, topY)
		{
			InitializeWallBorders();
		}
		private void SetHorizontalLine(int topY)
		{
			for (int i = 0; i < this.LeftX; i++)
			{
				Draw(i, topY, WALL_SYMBOL);
			}
		}
		private void SetVerticalLine(int leftX)
		{
			for (int i = 0; i < this.TopY; i++)
			{
				Draw(leftX, i, WALL_SYMBOL);
			}
		}
		private void InitializeWallBorders()
		{
			SetHorizontalLine(0);
			SetHorizontalLine(this.TopY);

			SetVerticalLine(0);
			SetVerticalLine(this.LeftX - 1);
		}
		public bool IsPointOfWall(Point snake)
		{
			return snake.LeftX == 0 || snake.TopY == 0 ||
				   snake.LeftX == this.LeftX - 1 || snake.TopY == this.TopY;
		}
	}
}
