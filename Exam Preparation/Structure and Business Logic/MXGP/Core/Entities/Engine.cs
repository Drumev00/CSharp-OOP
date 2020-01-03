using System;

using MXGP.IO;

namespace MXGP.Core.Entities
{
	public class Engine
	{
		private ChampionshipController championshipController;
		private ConsoleWriter writer;
		private ConsoleReader reader;
		public Engine()
		{
			championshipController = new ChampionshipController();
			writer = new ConsoleWriter();
			reader = new ConsoleReader();
		}

		public void Run()
		{
			string command = string.Empty;
			while ((command = reader.ReadLine()) != "End")
			{
				try
				{
					string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
					if (tokens[0] == "CreateRider")
					{
						string riderName = tokens[1];
						writer.WriteLine(championshipController.CreateRider(riderName));
					}
					else if (tokens[0] == "CreateMotorcycle")
					{
						string type = tokens[1];
						string model = tokens[2];
						int hp = int.Parse(tokens[3]);

						writer.WriteLine(championshipController.CreateMotorcycle(type, model, hp));
					}
					else if (tokens[0] == "AddMotorcycleToRider")
					{
						string riderName = tokens[1];
						string motorcycleName = tokens[2];

						writer.WriteLine(championshipController.AddMotorcycleToRider(riderName, motorcycleName));
					}
					else if (tokens[0] == "AddRiderToRace")
					{
						string raceName = tokens[1];
						string riderName = tokens[2];

						writer.WriteLine(championshipController.AddRiderToRace(raceName, riderName));
					}
					else if (tokens[0] == "CreateRace")
					{
						string name = tokens[1];
						int laps = int.Parse(tokens[2]);

						writer.WriteLine(championshipController.CreateRace(name, laps));
					}
					else if (tokens[0] == "StartRace")
					{
						string raceName = tokens[1];

						writer.WriteLine(championshipController.StartRace(raceName));
					}
				}
				catch (ArgumentException ae)
				{
					writer.WriteLine(ae.Message);
				}
				catch (InvalidOperationException ioe)
				{
					writer.WriteLine(ioe.Message);
				}
				championshipController.End();
			}
		}
	}
}
