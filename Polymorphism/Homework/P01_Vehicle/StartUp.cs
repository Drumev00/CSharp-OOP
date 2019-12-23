using P01_Vehicle.Core;

namespace P01_Vehicle
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			Engine engine = new Engine();
			engine.Run();
		}
	}
}
