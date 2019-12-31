using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
	public class CommandInterpreter : ICommandInterpreter
	{
		public string Read(string args)
		{
			string[] tokens = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			string commandName = $"{tokens[0]}Command";

			Assembly assembly = Assembly.GetCallingAssembly();
			Type[] types = assembly.GetTypes();
			Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);


			object classInstance = Activator.CreateInstance(typeToCreate, new object[] { });
			ICommand command = (ICommand)classInstance;
			string result = command.Execute(tokens.Skip(1).ToArray());

			return result;
		}
	}
}
