using Databasee;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWithInvalidParameters()
        {
            for (int i = 0; i < 10; i++)
            {
                this.database.Add(5);

            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(5));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 10; i++)
            {
                this.database.Add(10);

            }

            Assert.That(16, Is.EqualTo(this.database.Numbers.Length));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWithEmptyDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Remove();

            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());

        }

        [Test]
        public void RemoveMethodShouldRemoveOnlyOneElement()
        {
            this.database.Remove();

            Assert.That(5, Is.EqualTo(this.database.Numbers.Length));

        }

        [Test]
        public void ConstructorShouldInitialiseCorrectly()
        {
            this.database = new Database(1, 2, 3, 5);

            Assert.That(4, Is.EqualTo(this.database.Numbers.Length));

        }

        [Test]
        [TestCase()]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public void ConstructorShouldThrowException(params int[] collection)
        {
            
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(collection));

        }

        [Test]        
        public void Property_Numbers_Should_Set_Correctly()
        {
            var collection = new List<int>() { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(collection, this.database.Numbers);

        }

        [Test]
        public void Property_Numbers_Should_Get_Correctly()
        {
            int expectedCount = 6;

            Assert.That(expectedCount, Is.EqualTo(this.database.Numbers.Length));

        }
    }
}