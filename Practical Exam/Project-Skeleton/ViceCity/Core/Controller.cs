using System.Collections.Generic;
using System.Linq;
using System.Text;

using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
	public class Controller : IController
	{
		private IPlayer player;
		private GunRepository gunRepository;
		private ICollection<IPlayer> players;
		private GangNeighbourhood neighbourhood;
		public Controller()
		{
			this.player = new MainPlayer();
			gunRepository = new GunRepository();
			players = new List<IPlayer>();
			neighbourhood = new GangNeighbourhood();
		}
		public string AddGun(string type, string name)
		{
			IGun gun = null;
			string message = string.Empty;
			if (type != "Pistol" && type != "Rifle")
			{
				message = $"Invalid gun type!";
			}
			else
			{
				if (type == "Pistol")
				{
					gun = new Pistol(name);
				}
				else if (type == "Rifle")
				{
					gun = new Rifle(name);
				}
				gunRepository.Add(gun);
				message = $"Successfully added {name} of type: {type}";
			}

			return message;
		}

		public string AddGunToPlayer(string name)
		{
			IGun gun = null;
			if (gunRepository.Models.Count == 0)
			{
				return $"There are no guns in the queue!";
			}
			else
			{
				gun = gunRepository.Models.FirstOrDefault();
				if (name == "Vercetti")
				{
					player.GunRepository.Add(gun);
					gunRepository.Remove(gun);
					return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
				}
				else
				{
					IPlayer civilPlayer = this.players.FirstOrDefault(x => x.Name == name);
					if (civilPlayer == null)
					{
						return $"Civil player with that name doesn't exists!";
					}
					civilPlayer.GunRepository.Add(gun);
					gunRepository.Remove(gun);
					return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
				}
			}
		}

		public string AddPlayer(string name)
		{
			IPlayer currentPlayer = new CivilPlayer(name);
			players.Add(currentPlayer);

			return $"Successfully added civil player: {name}!";
		}

		public string Fight()
		{
			int tommysHealthBeforeFight = player.LifePoints;
			bool isEveryBodyFine = true;
			neighbourhood.Action(player, players);

			//if (!players.Any(x => x.IsAlive) || players.Any(x => x.LifePoints != 50))
			//{
			//	isEveryBodyFine = false;
			//}

			if (player.IsAlive && players.All(x => x.LifePoints == 50) && players.All(x => x.IsAlive) && players.Count != 0)
			{
				return "Everything is okay!";
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				var killedEnemiesList = players.Where(x => x.LifePoints == 0);
				int killedEnemiesCount = killedEnemiesList.Count();
				var livingEnemiesList = players.Where(x => x.IsAlive);
				int livingEnemiesCount = livingEnemiesList.Count();


				sb.AppendLine("A fight happened:");
				sb.AppendLine($"Tommy live points: {player.LifePoints}!");
				sb.AppendLine($"Tommy has killed: {killedEnemiesCount} players!");
				sb.AppendLine($"Left Civil Players: {livingEnemiesCount}!");

				return sb.ToString().TrimEnd();
				//int killedCivilians = 0;
				//neighbourhood.Action(player, players);
				//foreach (var civilian in players.ToList())
				//{
				//	if (!civilian.IsAlive)
				//	{
				//		players.Remove(civilian);
				//		killedCivilians++;
				//	}
				//}

				//if (player.IsAlive && players.All(x => x.LifePoints == 50) && players.All(x => x.IsAlive) && players.Count != 0)
				//{
				//	return $"Everything is okay!";
				//}
				//else
				//{

				//	StringBuilder sb = new StringBuilder();
				//	sb.AppendLine("A fight happened:")
				//		.AppendLine($"Tommy life points: {player.LifePoints}!")
				//		.AppendLine($"Tommy has killed: {killedCivilians} players!")
				//		.AppendLine($"Left Civil Players: {players.Count}!");

				//	return sb.ToString().TrimEnd();
				//}
			}
		}
	}
}
