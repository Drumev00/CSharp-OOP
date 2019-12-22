using P03_Ferrari.Interfaces;

namespace P03_Ferrari.Models
{
	public class Ferrari : IDrivable
	{
		private const string MODEL = "488-Spider";
		public string DriverName { get; set; }

		public Ferrari(string name)
		{
			this.DriverName = name;
		}

		public override string ToString()
		{
			return $"{MODEL}/{this.Brakes()}/{this.Gas()}/{this.DriverName}";
		}
		public string Brakes()
		{
			return "Brakes!";
		}

		public string Gas()
		{
			return "Gas!";
		}
	}
}
