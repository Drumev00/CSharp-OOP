using System;

using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
	public abstract class SpecialisedSoldier : Private,  ISpecialisedSoldier
	{
		public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
			: base(id, firstName, lastName, salary)
		{
			this.ValidateCorp(corps);
		}

		public Corp Corp { get; private set; }
		private void ValidateCorp(string corpStr)
		{
			Corp corp;
			bool valid = Enum.TryParse<Corp>(corpStr, out corp);
			if (valid)
			{
				this.Corp = corp;
			}
		}
		public override string ToString()
		{
			return base.ToString() + Environment.NewLine + $"Corps: {this.Corp}";
		}
	}
}
