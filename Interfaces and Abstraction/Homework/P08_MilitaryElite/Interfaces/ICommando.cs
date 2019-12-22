using System.Collections.Generic;

using P08_MilitaryElite.Models;

namespace P08_MilitaryElite.Interfaces
{
	public interface ICommando : ISpecialisedSoldier
	{
		IReadOnlyCollection<IMission> Missions { get; }
		void AddMission(IMission mission);
	}
}
