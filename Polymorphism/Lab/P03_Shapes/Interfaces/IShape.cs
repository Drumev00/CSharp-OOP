using System;

namespace Shapes.Interfaces
{
	public abstract class IShape
	{
		public abstract double CalculatePerimeter();
		public abstract double CalculateArea();
		public virtual void Draw()
		{
			Console.WriteLine("Do something");
		}
	}
}
