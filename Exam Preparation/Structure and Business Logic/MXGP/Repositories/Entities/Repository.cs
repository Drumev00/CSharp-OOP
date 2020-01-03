using System.Linq;
using System.Collections.Generic;

using MXGP.Repositories.Contracts;
using System;
using MXGP.Utilities.Messages;

namespace MXGP.Repositories.Entities
{
	public abstract class Repository<T> : IRepository<T>
	{
		protected readonly List<T> models;
		public Repository()
		{
			models = new List<T>();
		}
		public IReadOnlyCollection<T> Models => models;
		public virtual void Add(T model)
		{
			models.Add(model);
		}

		public IReadOnlyCollection<T> GetAll()
		{
			return Models;
		}

		public virtual T GetByName(string name)
		{
			T neededEntity = models.First(e => e.GetType().Name == name);

			return neededEntity;
		}

		public bool Remove(T model)
		{
			bool result = true;
			if (models.Contains(model))
			{
				models.Remove(model);
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
