using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void CheckIfAllGettersWorksCorrectly()
        {
            this.car = new Car("Golf", 50, 30, 0.2);

            var model = car.Model;
            var tankCapacity = car.TankCapacity;
            var tank = car.FuelAmount;
            var fuelConsumption = car.FuelConsumptionPerKm;

            var expectedModel = "Golf";
            var expectedTankCapacity = 50;
            var expectedTank = 30;
            var expectedFuelConsumption = 0.2;

            Assert.AreEqual(expectedModel, model);
            Assert.AreEqual(expectedTankCapacity, tankCapacity);
            Assert.AreEqual(expectedTank, tank);
            Assert.AreEqual(expectedFuelConsumption, fuelConsumption);
               
        }

        [Test]
        public void CheckIfModelSetterThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Car("", 50, 30, 0.2));
        }

        [Test]
        public void CheckIfFuelAmountSetterThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Car("Golf", 50, 56456, 0.2));
        }

        [Test]
        public void CheckIfFuelConsumptionSetterThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Car("Golf", 50, 30, -23));
        }

        [Test]
        public void CheckIfDriveMethodWorksCorrectly()
        {
            Car car = new Car("Golf", 60, 50, 0.2);

            string message = car.Drive(10);
            string expectedMessage = "Have a nice trip";

            double fuel = car.FuelAmount;
            double expectedFuel = 48;

            Assert.AreEqual(expectedFuel, fuel);
            Assert.AreEqual(message, expectedMessage);

        }

        [Test]
        public void CheckIfDriveMethodThrowsException()
        {
            Car car = new Car("Golf", 60, 50, 0.2);
            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        [Test]
        public void RefuelMethodShouldThrowException()
        {
            Car car = new Car("Golf", 60, 50, 0.2);
            Assert.Throws<InvalidOperationException>(() => car.Refuel(30));
        }

        [Test]
        public void RefuelMethodShouldIncreaseFuelAmount()
        {
            Car car = new Car("Golf", 60, 30, 0.2);

            car.Refuel(20);

            var actual = car.FuelAmount;
            var expected = 50;

            Assert.AreEqual(expected, actual);
        }
    }
}