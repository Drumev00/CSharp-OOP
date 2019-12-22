using System.Collections.Generic;
using System.Text;

using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
	public class Commando : SpecialisedSoldier, ICommando
	{
		public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
			: base(id, firstName, lastName, salary, corps)
		{
			this.missions = new List<IMission>();
		}
		private readonly List<IMission> missions;
		public IReadOnlyCollection<IMission> Missions => missions;

		public void AddMission(IMission mission)
		{
			missions.Add(mission);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(base.ToString())
			.AppendLine("Missions:");
			foreach (var mission in Missions)
			{
				if (mission.MissionState == State.inProgress)
				{
					sb.AppendLine($"  {mission.ToString().TrimEnd()}");
				}
			}

			return sb.ToString().TrimEnd();
		}
	}
}
