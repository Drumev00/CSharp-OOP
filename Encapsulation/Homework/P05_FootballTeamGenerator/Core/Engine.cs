using System;
using System.Collections.Generic;
using System.Linq;

using P05_FootballTeamGenerator.Models;
using P05_FootballTeamGenerator.Exceptions;

namespace P05_FootballTeamGenerator.Core
{
	public static class Engine
	{
		static List<Team> teams = new List<Team>();
		public static void Run()
		{
			string command = string.Empty;

			while ((command = Console.ReadLine()) != "END")
			{
				try
				{
					string[] tokens = command.Split(";");
					if (tokens[0] == "Team")
					{
						Team team = new Team(tokens[1]);
						teams.Add(team);
					}
					else if (tokens[0] == "Add")
					{
						Team neededTeam = FindTeam(tokens);
						if (neededTeam == null)
						{
							throw new InvalidOperationException
								(string.Format(ExceptionMessage.TeamDoesntExistException, tokens[1]));
						}
						else
						{
							Stat stats = new Stat(
								int.Parse(tokens[3]), int.Parse(tokens[4]),
								int.Parse(tokens[5]), int.Parse(tokens[6]),
								int.Parse(tokens[7]));
							Player player = new Player(tokens[2], stats);
							neededTeam.AddPlayer(player);
						}
					}
					else if (tokens[0] == "Remove")
					{
						Team neededTeam = FindTeam(tokens);
						neededTeam.RemovePlayer(tokens[2]);
					}
					else if (tokens[0] == "Rating")
					{
						Team neededTeam = FindTeam(tokens);
						if (neededTeam == null)
						{
							throw new InvalidOperationException(string.Format
								(ExceptionMessage.TeamDoesntExistException, tokens[1]));
						}
						else
						{
							Console.WriteLine(neededTeam.Rating());
						}
					}
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.Message);
				}
				catch (InvalidOperationException ioe)
				{
					Console.WriteLine(ioe.Message);
				}
			}
		}

		private static Team FindTeam(string[] tokens)
		{
			Team neededTeam = teams.FirstOrDefault(t => t.Name == tokens[1]);
			return neededTeam;
		}
	}
}
