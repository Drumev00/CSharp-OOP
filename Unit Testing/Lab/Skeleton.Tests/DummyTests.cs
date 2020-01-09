using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
	[TestFixture]
	public class DummyTests
	{
		[Test]
		public void Dummy_Looses_Health_Upon_Attack()
		{
			Axe axe = new Axe(8, 10);
			Dummy dummy = new Dummy(10, 10);

			dummy.TakeAttack(axe.AttackPoints);

			Assert.That(dummy.Health, Is.EqualTo(2));
		}
		[Test]
		public void Dummy_Throws_An_Exception_If_Attached_Already_Dead()
		{
			Axe axe = new Axe(10, 10);
			Dummy dummy = new Dummy(0, 10);


			Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
		}
		[Test]
		public void Dummy_Gives_EXP_When_Being_Killed()
		{
			Dummy dummy = new Dummy(10, 10);
			Hero hero = new Hero("Pesho");

			hero.Attack(dummy);
			dummy.GiveExperience();

			Assert.AreEqual(10, hero.Experience);
		}
		[Test]
		public void Alive_Dummy_Cant_Give_EXP()
		{
			Hero hero = new Hero("Batman");
			Dummy dummy = new Dummy(12, 10);

			hero.Attack(dummy);

			Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
		}
	}
}
