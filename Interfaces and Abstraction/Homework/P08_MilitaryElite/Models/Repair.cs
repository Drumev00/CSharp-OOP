using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
	public class Repair : IRepair
	{
		public string PartName { get; private set; }

		public int HoursWorked { get; private set; }
		public Repair(string partName, int hours)
		{
			this.PartName = partName;
			this.HoursWorked = hours;
		}

		public override string ToString()
		{
			return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
		}
	}
}
