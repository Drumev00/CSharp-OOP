using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
			List<IShape> shapes = new List<IShape>()
			{
				new Circle(),
				new Rectangle(),
				new Square()
			};
			foreach (var shape in shapes)
			{
				shape.DrawShape(shape);
			}
        }
    }
}
