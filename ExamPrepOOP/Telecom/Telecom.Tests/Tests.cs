namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void CheckIfGettersWorkCorrectly()
        {
            this.phone = new Phone("iPhone", "7Plus");

            string make = phone.Make;
            string model = phone.Model;

            var expectedMake = make;
            var expectedModel = model;

            Assert.AreEqual(expectedMake, make);
            Assert.AreEqual(expectedModel, model);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CheckIfMakeSetterThrowsExceptionIfEmpty(string test)
        {
            Assert.Throws<ArgumentException>(() => new Phone(test, "7Plus"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CheckIfModelSetterThrowsExceptionIfEmpty(string test)
        {
            Assert.Throws<ArgumentException>(() => new Phone("iPhone", test));
        }

        [Test]
        public void CheckIfAddPhoneMethodAddsNumberCorrectly()
        {
            this.phone = new Phone("iPhone", "7Plus");
            var name = "Ivan";
            var phone = "Iphone";

            var expectedName = name;
            var expectedPhone = phone;
            this.phone.AddContact(expectedName, expectedPhone);

            Assert.AreEqual(expectedName, name);
            Assert.AreEqual(expectedPhone, phone);

        }

        [Test]
        public void CheckIfAddPhoneMethodThrowException()
        {
            this.phone = new Phone("iPhone", "7Plus");

            var name = "Ivan";
            var phone = "Iphone";

            this.phone.AddContact(name, phone);

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Ivan", "Iphone"));
        }

        [Test]
        public void CheckIfCallMethodWorksCorrectly()
        {
            this.phone = new Phone("iPhone", "7Plus");

            var name = "Ivan";
            var phone = "7Plus";
            this.phone.AddContact(name, phone);

            var expectedCall = name;
            this.phone.Call(name);

            Assert.AreEqual(expectedCall, name);
        }
        [Test]
        public void CheckIfCallMethodThrowException()
        {
            this.phone = new Phone("iPhone", "7Plus");

            var name = "Ivan";
            var phone = "7Plus";
            this.phone.AddContact(name, phone);

            this.phone.Call(name);

            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Gosho"));
        }

        [Test]
        public void CheckIfCountWorkCorrectly()
        {
            this.phone = new Phone("iPhone", "7Plus");

            var name = "Ivan";
            var phoneNum = "7Plus";
            this.phone.AddContact(name, phoneNum);

            var expectedCount = this.phone.Count;

            Assert.AreEqual(expectedCount, this.phone.Count);
        }
    } 
}