using System;

using Shapes.Interfaces;

namespace Shapes.Models
{
	public class Rectangle : IShape
	{
		private double width;
		private double height;

		public double Width {
			get => this.width;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException();
				}
				this.width = value;
			}
		}
		public double Height {
			get => this.height;
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException();
				}
				this.height = value;
			}
		}

		public Rectangle(double width, double height)
		{
			this.Width = width;
			this.Height = height;
		}
		public override void Draw()
		{
			DrawLine('*', '*');
			for (int i = 0; i < Height - 2; i++)
			{
				DrawLine('*', ' ');
			}
			DrawLine('*', '*');

		}

		private void DrawLine (char borderSymbol, char innerSymbol)
		{
			Console.Write(borderSymbol);
			for (int i = 0; i < Width - 2; i++)
			{
				Console.Write(innerSymbol);
			}


			Console.WriteLine(borderSymbol);
		}

		public override double CalculatePerimeter()
		{
			return 2 * (Width + Height);
		}

		public override double CalculateArea()
		{
			return Width * Height;
		}
	}
}
