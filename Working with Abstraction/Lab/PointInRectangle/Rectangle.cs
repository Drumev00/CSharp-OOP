using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
	public class Rectangle
	{
		public Rectangle(Point x, Point y)
		{
			TopLeft = x;
			BottomRight = y;
		}

		public Point TopLeft { get; set; }
		public Point BottomRight { get; set; }

		public bool Contains(Point point)
		{
			bool validPoint = IsInside(point);
			return validPoint;
		}

		private bool IsInside(Point point)
		{
			bool isValid = false;
			if (TopLeft.XCoordinate <= point.XCoordinate && TopLeft.YCoordinate <= point.YCoordinate &&
				BottomRight.XCoordinate >= point.XCoordinate && BottomRight.YCoordinate >= point.YCoordinate)
			{
				isValid = true;
			}
			return isValid;
		}
	}
}
