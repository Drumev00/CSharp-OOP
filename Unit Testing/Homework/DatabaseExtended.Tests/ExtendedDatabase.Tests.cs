using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
		private ExtendedDatabase.ExtendedDatabase data;
		private Person firstPerson;
		private Person secondPerson;
        [SetUp]
        public void Setup()
        {
			this.firstPerson = new Person(0, "Pesho");
			this.secondPerson = new Person(1, "Gosho");
			this.data = new ExtendedDatabase.ExtendedDatabase(firstPerson, secondPerson);
        }

        [Test]
        public void TestIf_Constructor_Works_Properly()
        {
			Assert.AreEqual(2, data.Count);
        }
		[Test]
		public void TestIf_AddRange_Throws_Exception_When_Capacity_IsOverloaded()
		{
			Person[] people = new Person[20];
			people[0] = this.firstPerson;
			people[1] = this.secondPerson;
			for (int i = 3; i <= 16; i++)
			{
				Person person = new Person(i, "Az");
				people[i] = person;
			}

			Assert.Throws<ArgumentException>(() => this.data = new ExtendedDatabase.ExtendedDatabase(people));
		}
		[Test]
		public void TestIf_Add_Throws_Exception_When_Capacity_IsOverloaded()
		{
			Person[] people = new Person[20];
			people[0] = this.firstPerson;
			people[1] = this.secondPerson;
			for (int i = 3; i <= 16; i++)
			{
				Person person = new Person(i, "Az" + $"{i}");
				this.data.Add(person);
			}

			Assert.Throws<InvalidOperationException>(() => this.data.Add(new Person(17, "Ime")));
		}
		[Test]
		public void TestIf_Add_Throws_Exception_When_Theres_Already_PersonWithSame_Username()
		{
			Person person = new Person(2, "Pesho");

			Assert.Throws<InvalidOperationException>(() => this.data.Add(person));
		}
		[Test]
		public void TestIf_Add_Throws_Exception_When_Theres_Already_PersonWithSame_Id()
		{
			Person person = new Person(1, "Galen");

			Assert.Throws<InvalidOperationException>(() => this.data.Add(person));
		}
		[Test]
		public void TestIf_Add_Works_Properly()
		{
			Person person = new Person(2, "Galen");

			this.data.Add(person);

			Assert.AreEqual(3, this.data.Count);
		}
		[Test]
		public void TestIf_Remove_Works_Properly()
		{
			this.data.Remove();

			Assert.AreEqual(1, this.data.Count);
		}
		[Test]
		public void TestIf_Remove_Throws_Exception_WhenCountIsZero()
		{
			for (int i = 0; i < 2; i++)
			{
				this.data.Remove();
			}

			Assert.Throws<InvalidOperationException>(() => this.data.Remove());
		}
		[Test]
		public void TestIf_FindByUsername_Works_Properly()
		{
			Person person = this.data.FindByUsername("Pesho");

			Assert.AreEqual(person, this.firstPerson);
		}
		[Test]
		public void TestIf_FindByUsername_Throws_Exception_When_NameIsNull()
		{
			string name = null;

			Assert.Throws<ArgumentNullException>(() => this.data.FindByUsername(name));
		}
		[Test]
		public void TestIf_FindByUsername_Throws_Exception_When_Theres_No_Such_A_Name_InRepository()
		{
			string name = "Galen";

			Assert.Throws<InvalidOperationException>(() => this.data.FindByUsername(name));
		}
		[Test]
		public void TestIf_FindById_Throws_Exception_When_Id_IsNegative()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => this.data.FindById(-1));
		}
		[Test]
		public void TestIf_FindById_Throws_Exception_When_Theres_NoSuch_An_Id_InRepository()
		{
			Assert.Throws<InvalidOperationException>(() => this.data.FindById(4));
		}
		[Test]
		public void TestIf_FindById_Works_Properly()
		{
			Person person = this.data.FindById(0);

			Assert.AreEqual(person, this.firstPerson);
		}

	}
}