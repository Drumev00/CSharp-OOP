using P08_MilitaryElite.Models;

namespace P08_MilitaryElite.Interfaces
{
	public interface ISpecialisedSoldier : IPrivate
	{
		Corp Corp { get; }
	}
}
