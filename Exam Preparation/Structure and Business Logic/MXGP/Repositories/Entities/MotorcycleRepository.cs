using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Linq;

namespace MXGP.Repositories.Entities
{
	public class MotorcycleRepository : Repository<IMotorcycle>
	{
		public override void Add(IMotorcycle model)
		{
			if (Models.Any(x => x.Model == model.Model))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model.Model));
			}
			base.Add(model);
		}
		public override IMotorcycle GetByName(string name)
		{
			IMotorcycle motorcycle = Models.FirstOrDefault(x => x.Model == name);
			if (motorcycle == null)
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, name));
			}

			return motorcycle;
		}
	}
}
