using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
	public class BladeKnight : DarkKnight
	{
		public BladeKnight(string user, int level)
			: base(user, level)
		{
			this.Username = user;
			this.Level = level;
		}
	}
}
