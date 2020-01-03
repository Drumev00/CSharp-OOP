using System;
using System.Linq;
using System.Text;

using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Motorcycles.Entities;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Races.Entities;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Riders.Entities;
using MXGP.Repositories.Entities;
using MXGP.Utilities.Messages;

namespace MXGP.Core.Entities
{
	public class ChampionshipController : IChampionshipController
	{
		private RiderRepository riderRepository;
		private MotorcycleRepository motorcycleRepository;
		private RaceRepository raceRepository;
		public ChampionshipController()
		{
			riderRepository = new RiderRepository();
			motorcycleRepository = new MotorcycleRepository();
			raceRepository = new RaceRepository();
		}
		private int MIN_PARTICIPANTS = 3;
			
		public string AddMotorcycleToRider(string riderName, string motorcycleModel)
		{
			IRider rider = riderRepository.GetByName(riderName);
			IMotorcycle motorcycle = motorcycleRepository.GetByName(motorcycleModel);

			rider.AddMotorcycle(motorcycle);

			return $"{string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel)}";
		}

		public string AddRiderToRace(string raceName, string riderName)
		{
			IRace race = raceRepository.GetByName(raceName);
			IRider rider = riderRepository.GetByName(riderName);

			race.AddRider(rider);

			return $"{string.Format(OutputMessages.RiderAdded, riderName, raceName)}";
		}

		public string CreateMotorcycle(string type, string model, int horsePower)
		{
			IMotorcycle motorcycle = null;
			if (type == "Power")
			{
				motorcycle = new PowerMotorcycle(model, horsePower);
			}
			else if (type == "Speed")
			{
				motorcycle = new SpeedMotorcycle(model, horsePower);
			}
			motorcycleRepository.Add(motorcycle);

			return $"{string.Format(OutputMessages.MotorcycleCreated, type + "Motorcycle", model)}";
		}

		public string CreateRace(string name, int laps)
		{
			IRace race = new Race(name, laps);
			raceRepository.Add(race);

			return $"{string.Format(OutputMessages.RaceCreated, name)}";
		}

		public string CreateRider(string riderName)
		{
			Rider rider = new Rider(riderName);
			riderRepository.Add(rider);

			return string.Format(OutputMessages.RiderCreated, riderName);
		}

		public string StartRace(string raceName)
		{
			StringBuilder sb = new StringBuilder();
			IRace race = raceRepository.GetByName(raceName);
			IRider[] riders = riderRepository.Models.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToArray();
			if (riders.Count() < 3)
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_PARTICIPANTS));
			}


			sb.AppendLine($"Rider {riders[0].Name} wins {raceName} race.")
			.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.")
			.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

			return sb.ToString().TrimEnd();
		}
		public void End()
		{
			Environment.Exit(0);
		}
	}
}
