using System.Collections.Generic;

namespace P08_MilitaryElite.Interfaces
{
	public interface ILieutenantGeneral : IPrivate
	{
		IReadOnlyCollection<ISoldier> Privates { get; }
		void AddPrivate(ISoldier @private);
	}
}
