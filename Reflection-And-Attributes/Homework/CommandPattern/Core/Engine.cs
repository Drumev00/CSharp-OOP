using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
	public class Engine : IEngine
	{
		private readonly ICommandInterpreter commandInterpreter;
		public Engine(ICommandInterpreter commandInterpreter)
		{
			this.commandInterpreter = commandInterpreter;
		}
		public void Run()
		{
			string command = Console.ReadLine();
			Console.WriteLine(commandInterpreter.Read(command));
		}
	}
}
