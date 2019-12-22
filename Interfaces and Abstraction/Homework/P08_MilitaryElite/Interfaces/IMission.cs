using P08_MilitaryElite.Models;

namespace P08_MilitaryElite.Interfaces
{
	public interface IMission
	{
		string CodeName { get; }
		State MissionState { get; }
		void CompleteMission();
	}
}
