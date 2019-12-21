namespace P05_FootballTeamGenerator.Exceptions
{
	public static class ExceptionMessage
	{
		public static string StatOutOfRangeException = "{0} should be between 0 and 100.";

		public static string NameCannotBeEmptyException = "A name should not be empty.";

		public static string PlayerDoesntExistException = "Player {0} is not in {1} team.";

		public static string TeamDoesntExistException = "Team {0} does not exist.";
	}
}
