using MXGP.Models.Races.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Linq;

namespace MXGP.Repositories.Entities
{
	public class RaceRepository : Repository<IRace>
	{
		public override IRace GetByName(string name)
		{
			IRace race = Models.FirstOrDefault(x => x.Name == name);
			if (race == null)
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, name));
			}

			return race;
		}
		public override void Add(IRace model)
		{
			if (Models.Any(x => x.Name == model.Name))
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, model.Name));
			}
			base.Add(model);
		}
	}
}
