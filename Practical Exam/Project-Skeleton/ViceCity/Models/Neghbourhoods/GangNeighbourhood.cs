using System.Collections.Generic;
using System.Linq;

using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
	public class GangNeighbourhood : INeighbourhood
	{
		public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
		{
			IGun currentGun = null;
			

			foreach (var civilian in civilPlayers)
			{
				if (mainPlayer.GunRepository.Models.Count > 0)
				{
					currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);
				}
				while (civilian.IsAlive)
				{
					if (currentGun == null)
					{
						break;
					}
					if (!currentGun.CanFire)
					{
						mainPlayer.GunRepository.Remove(currentGun);
						if (mainPlayer.GunRepository.Models.Count == 0)
						{
							break;
						}

						currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);
					}

					civilian.TakeLifePoints(currentGun.Fire());
				}

			}
			var survivedCivilians = civilPlayers.Where(x => x.IsAlive).ToList();
			if (survivedCivilians.Count > 0)
			{
				foreach (var survivor in survivedCivilians)
				{
					IGun civilianGun = survivor.GunRepository.Models.FirstOrDefault(g => g.CanFire);
					while (mainPlayer.IsAlive)
					{
						if (civilianGun == null)
						{
							break;
						}
						if (!civilianGun.CanFire)
						{
							survivor.GunRepository.Remove(civilianGun);

							civilianGun = survivor.GunRepository.Models.FirstOrDefault(g => g.CanFire);
						}

						mainPlayer.TakeLifePoints(civilianGun.Fire());
					}
				}
			}
			//var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);
			//foreach (var civilPlayer in civilPlayers)
			//{
			//	while (civilPlayer.IsAlive)
			//	{


			//		if (currentGun == null)
			//		{
			//			break;
			//		}

			//		while (currentGun.CanFire)
			//		{
			//			int lifeToTake = currentGun.Fire();

			//			civilPlayer.TakeLifePoints(lifeToTake);
			//		}

			//	}

			//}

			//foreach (var civilPlayer in civilPlayers.Where(x => x.IsAlive))
			//{
			//	while (mainPlayer.IsAlive)
			//	{
			//		var currentGun2 = civilPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

			//		if (currentGun2 == null)
			//		{
			//			break;
			//		}

			//		while (currentGun2.CanFire)
			//		{
			//			int lifeToTake = currentGun2.Fire();

			//			mainPlayer.TakeLifePoints(lifeToTake);
			//		}

			//	}
			//}
		}


	}


	}

