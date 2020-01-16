using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
	public class MainPlayer : Player
	{
		public MainPlayer(string name = "Tommy Vercetti", int lifePoints = 100)
			: base(name, lifePoints)
		{

		}
	}
}
