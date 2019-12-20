using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
	public class Elf : Hero
	{
		public Elf(string user, int level)
			:base(user, level)
		{
			this.Username = user;
			this.Level = level;
		}
	}
}
