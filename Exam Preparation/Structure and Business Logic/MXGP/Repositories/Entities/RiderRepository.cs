using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Linq;

namespace MXGP.Repositories.Entities
{
	public class RiderRepository : Repository<IRider>
	{
		public override void Add(IRider model)
		{
			if (models.Any(x => x.Name == model.Name))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, model.Name));
			}
			base.Add(model);
		}
		public override IRider GetByName(string name)
		{
			IRider rider = null;
			rider = Models.FirstOrDefault(x => x.Name == name);
			if (rider == null)
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, name));
			}

			return rider;
		}
	}
}
