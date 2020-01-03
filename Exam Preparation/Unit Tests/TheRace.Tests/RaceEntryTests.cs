using NUnit.Framework;
using System;

namespace TheRace.Tests
{
	public class RaceEntryTests
	{
		private UnitMotorcycle motorcycle;
		private UnitRider rider;
		private RaceEntry race;
		[SetUp]
		public void Setup()
		{
			motorcycle = new UnitMotorcycle("Honda", 120, 200);
			rider = new UnitRider("Grisho", motorcycle);
			race = new RaceEntry();
		}
		[Test]
		public void MotorcycleConstructorTest()
		{
			UnitMotorcycle anotherMotorcycle = new UnitMotorcycle("Honda", 120, 200);

			Assert.AreEqual(this.motorcycle.Model, anotherMotorcycle.Model);
			Assert.AreEqual(this.motorcycle.HorsePower, anotherMotorcycle.HorsePower);
			Assert.AreEqual(this.motorcycle.CubicCentimeters, anotherMotorcycle.CubicCentimeters);
		}
		[Test]
		public void RiderConstructorTest()
		{
			UnitRider anotherRider = new UnitRider("Grisho", motorcycle);

			Assert.AreEqual(this.rider.Name, anotherRider.Name);
			Assert.AreEqual(this.rider.Motorcycle, anotherRider.Motorcycle);
		}
		[Test]
		public void RiderThrowsExceptionWhenNameIsNull()
		{
			UnitRider anotherRider;

			Assert.Throws<ArgumentNullException>(() => anotherRider = new UnitRider(null, motorcycle));
		}
		[Test]
		public void TestMethod_AddRider_WhetherThrowsExceptionWhenRiderIsNull()
		{
			Assert.Throws<InvalidOperationException>(() => race.AddRider(null));
		}
		[Test]
		public void TestMethod_AddRider_WhetherThrowsExceptionWhenRiderExists()
		{
			race.AddRider(this.rider);
			UnitRider anotherRider = new UnitRider("Grisho", motorcycle);

			Assert.Throws<InvalidOperationException>(() => race.AddRider(anotherRider));
		}
		[Test]
		public void TestMethod_AddRider_WorksProperly()
		{
			race.AddRider(this.rider);
			UnitRider anotherRider = new UnitRider("Griiiishoooo", motorcycle);
			race.AddRider(anotherRider);

			Assert.AreEqual(2, this.race.Counter);
		}
		[Test]
		public void TestMethod_CalculateAverageHP_WhetherThrowsExceptionWhen_Participants_Arent_Enough()
		{
			race.AddRider(this.rider);

			Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
		}
		[Test]
		public void TestMethod_CalculateAverageHP_WhetherWorksProperly()
		{
			race.AddRider(this.rider);
			UnitRider anotherRider = new UnitRider("Griiishooo", motorcycle);
			race.AddRider(anotherRider);

			Assert.AreEqual(120, race.CalculateAverageHorsePower());
		}

	}
}