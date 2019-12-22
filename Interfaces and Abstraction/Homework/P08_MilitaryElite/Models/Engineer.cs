using System.Collections.Generic;
using System.Text;

using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
	public class Engineer : SpecialisedSoldier, IEngineer
	{
		private readonly List<IRepair> repairs;

		public Engineer(string id, string firstName, string lastName, decimal salary, string corps) 
			: base(id, firstName, lastName, salary, corps)
		{
			this.repairs = new List<IRepair>();
		}

		public IReadOnlyCollection<IRepair> Repairs => repairs;

		public void AddRepair(IRepair repair)
		{
			repairs.Add(repair);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(base.ToString())
			.AppendLine("Repairs:");
			foreach (var repair in Repairs)
			{
				sb.AppendLine($"  {repair.ToString().TrimEnd()}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
