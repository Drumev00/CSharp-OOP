using System;

using System.Collections.Generic;

using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter
{
	public class Manager : IManager
	{
		public Manager(string name, ICollection<string> documents)
		{
			this.Name = name;
			this.Documents = new List<string>(documents);
		}

		public IReadOnlyCollection<string> Documents { get; set; }
		public string Name { get; set; }

		public void PrintOutput()
		{
			Console.WriteLine(this.Name);
			Console.WriteLine(string.Join(Environment.NewLine, this.Documents));
		}
	}
}
