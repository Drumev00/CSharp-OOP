using System;
using System.Linq;

namespace P05_GreedyTimes
{

	public class Potato
	{
		static long amount;
		static void Main(string[] args)
		{
			Bag bag = new Bag();
			long bagCapacity = long.Parse(Console.ReadLine());
			bag.Capacity = bagCapacity;
			// USD 1030 Gold 300000 EmeraldGem 900000 Topazgem 290000 CHF 280000 Gold 10000000 JPN 10000 Rubygem 10000000 KLM 3120010
			string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			long gold = 0;
			long rocks = 0;
			long cash = 0;

			for (int i = 0; i < safe.Length; i += 2)
			{
				string name = safe[i];
				amount = long.Parse(safe[i + 1]);

				string item = string.Empty;

				if (name.Length == 3)
				{
					item = "Cash";
				}
				else if (name.ToLower().EndsWith("gem"))
				{
					item = "Gem";
				}
				else if (name.ToLower() == "gold")
				{
					item = "Gold";
				}

				if (item == "")
				{
					continue;
				}
				else if (bag.Capacity < bag.Items.Sum(x => x.Value.Amount) + amount)
				{
					continue;
				}

				switch (item)
				{
					case "Gem":
						if (!bag.Items.ContainsKey(item))
						{
							if (bag.Items.ContainsKey("Gold"))
							{
								if (amount > bag.Items["Gold"].Amount)
								{
									continue;
								}
							}
							else
							{
								continue;
							}
						}
						else if (bag.Items[item].Amount + amount > bag.Items["Gold"].Amount)
						{
							continue;
						}
						break;
					case "Cash":
						if (!bag.Items.ContainsKey(item))
						{
							if (bag.Items.ContainsKey("Gem"))
							{
								if (amount > bag.Items["Gem"].Amount)
								{
									continue;
								}
							}
							else
							{
								continue;
							}
						}
						else if (bag.Items[item].Amount + amount > bag.Items["Gem"].Amount)
						{
							continue;
						}
						break;
				}

				if (!bag.Items.ContainsKey(item))
				{
					bag.Items.Add(item, new Item());

					bag.Items[item].Amount += amount;
					if (item == "Gold")
					{
						gold += amount;
					}
					else if (item == "Gem")
					{
						rocks += amount;
					}
					else if (item == "Cash")
					{
						cash += amount;
					}
					bag.Items[item].Name = name;
				}
			}
			foreach (var x in bag.Items.OrderByDescending(y => y.Value.Amount).ThenByDescending(u => u.Key).ThenBy(b => amount))
			{
				Console.WriteLine($"<{x.Key}> ${x.Value.Amount}");
				Console.WriteLine($"##{x.Value.Name} - {x.Value.Amount}");
			}
		}
	}
}