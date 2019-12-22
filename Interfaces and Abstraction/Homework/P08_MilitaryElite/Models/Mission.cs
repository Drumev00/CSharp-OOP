using System;

using P08_MilitaryElite.Interfaces;

namespace P08_MilitaryElite.Models
{
	public class Mission : IMission
	{
		public string CodeName { get; private set; }

		public State MissionState { get; private set; }
		public Mission(string codeName, string state)
		{
			this.CodeName = codeName;
			ValidateMissionState(state);
		}

		public void CompleteMission()
		{
			MissionState = State.Finished;
		}
		private void ValidateMissionState(string stateStr)
		{
			State state;
			bool validState = Enum.TryParse<State>(stateStr, out state);
			if (validState)
			{
				this.MissionState = state;
			}
		}

		public override string ToString()
		{
			return $"Code Name: {this.CodeName} State: {this.MissionState}";
		}
	}
}
