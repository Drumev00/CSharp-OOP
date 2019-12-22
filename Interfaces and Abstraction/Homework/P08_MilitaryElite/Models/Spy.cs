using System;

using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
	public class Spy : Soldier, ISpy
	{
		public Spy(string id, string firstName, string lastName, int codeNumber) 
			: base(id, firstName, lastName)
		{
			this.CodeNumber = codeNumber;
		}

		public int CodeNumber { get; private set; }

		public override string ToString()
		{
			return base.ToString() + Environment.NewLine + $"Code Number: {this.CodeNumber}";
		}
	}
}
