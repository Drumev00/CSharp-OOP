using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
		private Database.Database data;
		private int[] array;
        [SetUp]
        public void Setup()
        {
			array = new int[] { 1, 2, 3 };
			this.data = new Database.Database(array);
        }

        [Test]
        public void TestIf_AddingMoreThan_Capacity_ThrowsException()
        {
			for (int i = 3; i < 16; i++)
			{
				this.data.Add(i);
			}

			Assert.Throws<InvalidOperationException>(() => this.data.Add(17));
        }
		[Test]
		public void TestIf_Remove_Properly()
		{
			this.data.Remove();

			Assert.AreEqual(2, this.data.Count);
		}
		[Test]
		public void TestIf_Remove_Throws_ExceptionWhenNeeded()
		{
			int count = this.data.Count;
			for (int i = 0; i < count; i++)
			{
				this.data.Remove();
			}

			Assert.Throws<InvalidOperationException>(() => this.data.Remove());
		}
		[Test]
		public void TestIf_Fetching_Works_Properly()
		{
			int[] temp = new int[this.data.Count];
			

			for (int i = 0; i < temp.Length; i++)
			{
				temp[i] = array[i];
			}

			CollectionAssert.AreEqual(temp, this.data.Fetch());
		}
    }
}