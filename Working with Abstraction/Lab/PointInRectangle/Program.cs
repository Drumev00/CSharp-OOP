using System;
using System.Linq;

namespace PointInRectangle
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] borders = MakeArray();
			Point[] points = new Point[2];
			points[0] = new Point(borders[0], borders[1]);
			points[1] = new Point(borders[2], borders[3]);
			var rectangle = new Rectangle(points[0], points[1]);

			int inputLines = int.Parse(Console.ReadLine());
			for (int i = 0; i < inputLines; i++)
			{
				int[] indexes = MakeArray();
				var point = new Point(indexes[0], indexes[1]);
				Console.WriteLine(rectangle.Contains(point));
			}
		}

		private static int[] MakeArray()
		{
			return Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();
		}
	}
}
