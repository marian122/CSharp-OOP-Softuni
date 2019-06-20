using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        private People firstPerson;
        private People secondPerson;

        [SetUp]
        public void Setup()
        {
            this.firstPerson = new People(12, "Ivancho");
            this.secondPerson = new People(13, "Gosho");
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            var expectedResult = new People[] { firstPerson, secondPerson };

            var database = new Database(expectedResult);

            var actualResult = database.Fetch();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }


        [Test]
        public void AddMethodShouldThrowExeptionWithInvalidOperationIfAddingExistingPersonWithSameUsername()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);
            var pers = new People(54, "Ivancho");

            Assert.Throws<InvalidOperationException>(() => database.Add(pers));
        }

        [Test]
        public void AddMethodShouldThrowExeptionWithInvalidOperationIfAddingExistingPersonWithSameId()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);
            var pers = new People(12, "Ivancho");

            Assert.Throws<InvalidOperationException>(() => database.Add(pers));
        }

        public void RemoveShouldRemoveTheLastPerson()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);
            database.Remove();

            var expectedResult = new People[] { firstPerson };
            var actualResult = database.Fetch();


            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveShoultThrowExceptionWhenDatabaseIsEmpty()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenThereIsNoUserWithThatName()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Ivo"));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenIsNull()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenIsNotWithCaseSensitive()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);

            Assert.Throws<ArgumentException>(() => database.FindByUsername("ivo"));
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenThereIsNoUserWithThatId()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);

            Assert.Throws<InvalidOperationException>(() => database.FindById(14));
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenThereIsNegativeId()
        {
            var person = new People[] { firstPerson, secondPerson };
            var database = new Database(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1545));
        }
    }
}