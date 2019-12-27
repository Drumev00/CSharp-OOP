using System.Collections.Generic;

namespace P03.Detail_Printer.Contracts
{
	public interface IManager : IEmployee
	{
		IReadOnlyCollection<string> Documents { get; set; }
	}
}
