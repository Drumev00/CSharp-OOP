using System;

using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

		public void PrintOutput()
		{
			Console.WriteLine(this.Name);
		}
	}
}
