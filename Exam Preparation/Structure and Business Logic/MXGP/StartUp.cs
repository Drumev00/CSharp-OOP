using System;

namespace MXGP
{
    using IO;
    using MXGP.Core.Entities;
    using MXGP.Models.Motorcycles.Entities;

    public class StartUp
    {
        public static void Main(string[] args)
        {
			//TODO Add IEngine
			Engine engine = new Engine();
			engine.Run();
        }
    }
}
