using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
	public class Pistol : Gun
	{
		public Pistol(string name, int bulletsPerBarrel = 10, int totalBullets = 100) 
			: base(name, bulletsPerBarrel, totalBullets)
		{

		}

		public override int Fire()
		{
			int firedBullets = 0;

			this.BulletsPerBarrel -= 1;
			firedBullets++;
			if (this.BulletsPerBarrel == 0)
			{
				if (this.TotalBullets >= 10)
				{
					this.TotalBullets -= 10;
					this.BulletsPerBarrel += 10;
				}
			}

			return firedBullets;
		}
	}
}
