using System.Collections.Generic;

namespace P01_RawData
{
	public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
			this.Engine = new Engine(engine.Speed, engine.Power);
			this.Cargo = new Cargo(cargo.Weight, cargo.Type);
			this.Tires = new Tire[tires.Length];
			for (int i = 0; i < tires.Length; i++)
			{
				Tires[i] = new Tire(tires[i].Age, tires[i].Pressure);
			}
        }
		public string Model { get; set; }
		public Engine Engine { get; set; }
		public Cargo Cargo { get; set; }
		public Tire[] Tires { get; set; }
	}
}
