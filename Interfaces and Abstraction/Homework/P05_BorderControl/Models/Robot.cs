using P05_BorderControl.Interfaces;

namespace P05_BorderControl.Models
{
	public class Robot : IRobot
	{
		public string Model { get; }

		public string Id { get; }
		public Robot(string model, string id)
		{
			this.Model = model;
			this.Id = id;
		}
	}
}
