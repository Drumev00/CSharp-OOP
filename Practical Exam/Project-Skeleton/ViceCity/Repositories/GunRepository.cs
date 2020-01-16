using System.Collections.Generic;
using System.Linq;

using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
	public class GunRepository : IRepository<IGun>
	{
		private readonly List<IGun> models;
		public GunRepository()
		{
			models = new List<IGun>();
		}
		public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

		public void Add(IGun model)
		{
			if (!this.Models.Any(n => n.Name == model.Name))
			{
				this.models.Add(model);
			}
		}

		// Can return null
		public IGun Find(string name)
		{
			IGun gun = this.Models.FirstOrDefault(x => x.Name == name);

			return gun;
		}

		public bool Remove(IGun model)
		{
			bool removed = false;

			if (model != null)
			{

				IGun gun = Find(model.Name);
				if (gun != null)
				{
					this.models.Remove(gun);
					removed = true;
				}
			}
			return removed;
		}
	}
}
