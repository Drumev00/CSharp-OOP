using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
	public class Point
	{
		public Point(int x, int y)
		{
			XCoordinate = x;
			YCoordinate = y;
		} 

		public int XCoordinate { get; set; }
		public int YCoordinate { get; set; }
	}
}
