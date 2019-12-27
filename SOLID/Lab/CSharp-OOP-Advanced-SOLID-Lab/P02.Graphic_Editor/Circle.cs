using System;

namespace P02.Graphic_Editor
{
	public class Circle : IShape
	{
		public void DrawShape(IShape shape)
		{
			Console.WriteLine("I'm Circle");
		}
	}
}
