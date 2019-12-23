using System;

using Shapes.Interfaces;

namespace Shapes.Models
{
	public class Circle : IShape
	{
		private double radius;
		public double Radius {
			get => this.radius;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException();
				}
				this.radius = value;
			}
		}

		public Circle(double radius)
		{
			this.Radius = radius;
		}
		public override void Draw()
		{
			double thickness = 0.4;
			double rIn = Radius - thickness;
			double rOut = Radius + thickness;
			for (double i = Radius; i >= -Radius; i--)
			{
				for (double j = -Radius; j < rOut; j += 0.5)
				{
					double point = i * i + j * j;
					if (point > rIn * rIn && point < rOut * rOut)
					{
						Console.Write('*');
					}
					else
					{
						Console.Write(' ');
					}
				}
				Console.WriteLine();
			}
		}

		public override double CalculatePerimeter()
		{
			return 2 * Math.PI * Radius;
		}

		public override double CalculateArea()
		{
			return Math.PI * Radius * Radius;
		}
	}
}
