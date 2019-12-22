using System;

using P04_Telephony.Models;

namespace P04_Telephony
{
	class Program
	{
		static void Main(string[] args)
		{
			var smartphone = new Smartphone();
			string[] numberTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < numberTokens.Length; i++)
			{
				smartphone.Call(numberTokens[i]);
			}
			string[] websiteTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < websiteTokens.Length; i++)
			{
				smartphone.Browse(websiteTokens[i]);
			}
		}
	}
}
