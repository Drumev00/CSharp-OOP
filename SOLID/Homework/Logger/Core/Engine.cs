using System;

using Logger.Factories;
using Logger.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core
{
	public class Engine
	{
		private ILogger logger;
		private ErrorFactory errorFactory;
		public Engine(ILogger logger)
		{
			this.logger = logger;
			errorFactory = new ErrorFactory();
		}

		public void Run()
		{
			string command = string.Empty;
			while ((command = Console.ReadLine()) != "END")
			{
				string[] errorArgs = command.Split("|");

				string level = errorArgs[0];
				string date = errorArgs[1];
				string message = errorArgs[2];
				IError error;
				try
				{
					error = this.errorFactory.GetError(date, level, message);
					this.logger.Log(error);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
			Console.WriteLine(this.logger);
		}
	}
}
