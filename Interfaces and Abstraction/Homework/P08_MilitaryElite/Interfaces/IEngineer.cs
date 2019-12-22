using System.Collections.Generic;

using P08_MilitaryElite.Models;

namespace P08_MilitaryElite.Interfaces
{
	public interface IEngineer : ISpecialisedSoldier
	{
		IReadOnlyCollection<IRepair> Repairs { get; }
		void AddRepair(IRepair repair);
	}
}
