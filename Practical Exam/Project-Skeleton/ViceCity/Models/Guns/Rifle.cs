namespace ViceCity.Models.Guns
{
	public class Rifle : Gun
	{
		public Rifle(string name, int bulletsPerBarrel = 50, int totalBullets = 500) 
			: base(name, bulletsPerBarrel, totalBullets)
		{

		}

		public override int Fire()
		{
			int firedBullets = 0;

			this.BulletsPerBarrel -= 5;
			firedBullets += 5;

			if (this.BulletsPerBarrel == 0)
			{
				if (this.TotalBullets >= 50)
				{
					this.TotalBullets -= 50;
					this.BulletsPerBarrel += 50;
				}
			}

			return firedBullets;
		}
	}
}
