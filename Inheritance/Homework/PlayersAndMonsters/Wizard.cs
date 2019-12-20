using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
	public class Wizard : Hero
	{
		public Wizard(string user, int level)
			: base(user, level)
		{
			this.Username = user;
			this.Level = level;
		}
	}
}
