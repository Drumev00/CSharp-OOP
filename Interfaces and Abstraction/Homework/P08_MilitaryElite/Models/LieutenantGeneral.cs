using System.Collections.Generic;
using System.Text;

using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
	public class LieutenantGeneral : Private, ILieutenantGeneral
	{
		private readonly List<ISoldier> privates;
		public IReadOnlyCollection<ISoldier> Privates => privates;

		public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
			:base(id, firstName, lastName, salary)
		{
			this.privates = new List<ISoldier>();
		}

		public void AddPrivate(ISoldier @private)
		{
			privates.Add(@private);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(base.ToString())
			.AppendLine("Privates:");
			foreach (var troop in Privates)
			{
				sb.AppendLine($"  {troop.ToString().TrimEnd()}");
			}
			return sb.ToString().TrimEnd();
		}
	}
}
