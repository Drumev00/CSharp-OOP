using System;

namespace P02.Graphic_Editor
{
	public class Square : IShape
	{
		public void DrawShape(IShape shape)
		{
			Console.WriteLine("I'm Square");
		}
	}
}
