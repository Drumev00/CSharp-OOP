using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class AxeTests
	{
		[Test]
		public void Axe_Looses_Durability_After_Attack()
		{
			Axe axe = new Axe(10, 10);
			Dummy dummy = new Dummy(10, 10);

			axe.Attack(dummy);

			Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
		}
	}
}