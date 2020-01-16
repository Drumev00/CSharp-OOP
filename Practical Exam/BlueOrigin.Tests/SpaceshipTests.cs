namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
		private Astronaut astronaut;
		private Spaceship spaceship;
       [SetUp]
	   public void SetUp()
		{
			astronaut = new Astronaut("Grisho", 60);
			spaceship = new Spaceship("GrishoStation", 8);
		}
		[Test]
		public void Test_Whether_Astronaut_Constructor_Works_Properly()
		{
			Assert.AreEqual("Grisho", astronaut.Name);
			Assert.AreEqual(60, astronaut.OxygenInPercentage);
		}
		[Test]
		public void Test_Whether_Spaceship_Constructor_Works_Properly()
		{
			Assert.AreEqual("GrishoStation", spaceship.Name);
			Assert.AreEqual(8, spaceship.Capacity);
			Assert.AreEqual(0, spaceship.Count);
		}
		[Test]
		public void Test_Whether_Name_Property_Throws_Exception_When_Is_Null()
		{
			Assert.Throws<ArgumentNullException>(() => spaceship = new Spaceship(null, 8));
		}
		[Test]
		public void Test_Whether_Capacity_Property_Throws_Exception_When_Is_Less_Than_Zero()
		{
			Assert.Throws<ArgumentException>(() => spaceship = new Spaceship("GrishoStation", -2));
		}
		[Test]
		public void Test_Whether_AddMethod_Throws_Exception_When_Capacity_Is_At_Its_Max()
		{
			spaceship = new Spaceship("GrishoStation", 0);

			Assert.Throws<InvalidOperationException>(() => spaceship.Add(this.astronaut));
		}
		[Test]
		public void Test_Whether_AddMethod_Throws_Exception_When_Astronaut_Already_Exists()
		{
			spaceship.Add(this.astronaut);
			var anotherAstronaut = new Astronaut("Grisho", 45);

			Assert.Throws<InvalidOperationException>(() => spaceship.Add(anotherAstronaut));
		}
		[Test]
		public void Test_Whether_AddMethod_Works_Properly()
		{
			spaceship.Add(this.astronaut);
			var anotherAstronaut = new Astronaut("Griiishooo", 45);
			spaceship.Add(anotherAstronaut);

			Assert.AreEqual(2, this.spaceship.Count);
		}
		[Test]
		public void Test_Whether_RemoveMethod_Throws_Exception_When_Parameter_Is_Null()
		{
			spaceship.Add(this.astronaut);
			spaceship.Remove("Grisho");

			Assert.AreEqual(0, this.spaceship.Count);
		}


	}
}