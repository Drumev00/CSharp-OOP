using System.Collections.Generic;

namespace P05_GreedyTimes
{
	public class Bag
	{
		public Bag()
		{
			this.Items = new Dictionary<string, Item>();
		}

		public long Capacity { get; set; }
		public Dictionary<string, Item> Items { get; set; }
	}
}
