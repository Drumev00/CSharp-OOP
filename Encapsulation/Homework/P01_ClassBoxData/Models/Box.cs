using System;
using System.Text;
using P01_ClassBoxData.Exceptions;

namespace P01_ClassBoxData.Models
{
	public class Box
	{
		private double length;
		private double width;
		private double height;

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}

		public double Length
		{
			get
			{
				return this.length;
			}
			private set
			{
				ValidateSide(value, nameof(Length));
				this.length = value;
			}
		}
		public double Width
		{
			get
			{
				return this.width;
			}
			private set
			{
				ValidateSide(value, nameof(Width));
				this.width = value;
			}
		}
		public double Height
		{
			get
			{
				return this.height;
			}
			private set
			{
				ValidateSide(value, nameof(Height));
				this.height = value;
			}
		}

		public double SurfaceArea()
		{
			double area = (2 * Length * Width) + LateralSurfaceArea();

			return area;
		}
		public double LateralSurfaceArea()
		{
			double area = (2 * Length * Height)
				+ (2 * Width * Height);

			return area;
		}
		public double Volume()
		{
			return Length * Width * Height;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
			sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
			sb.AppendLine($"Volume - {this.Volume():F2}");

			return sb.ToString().TrimEnd();
		}


		private void ValidateSide(double value, string whichSide)
		{
			if (value <= 0)
			{
				throw new ArgumentException(string.Format(ExceptionMessage.InvalidSize, whichSide));
			}
		}
	}
}
