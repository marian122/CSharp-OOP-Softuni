using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        private Car firstCar;
        private Car secondCar;

        [SetUp]
        public void Setup()
        {
            
        }
        
        [Test]
        public void TestPropertyGettersWorkCorrectly()
        {
            Car car = new Car("Golf", 60, 50, 0.2);

            string model = car.Model;
            double capacity = car.TankCapacity;
            double fuel = car.FuelAmount;
            double consumption = car.FuelConsumptionPerKm;

            string expectedModel = "Golf";
            double expectedCapacity = 60;
            double expectedFuel = 50;
            double expectedConsumption = 0.2;

            Assert.AreEqual(expectedCapacity, capacity, "Capacity getter does not work correctly");
            Assert.AreEqual(expectedModel, model, "Model getter does not work correctly");
            Assert.AreEqual(expectedFuel, fuel, "Fuel getter does not work correctly");
            Assert.AreEqual(expectedConsumption, consumption, "Consumption getter does not work correctly");

        }

        [Test]
        public void ThrowArgumentExceptionIfModelNameIsEmptyOrWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Car("", 60, 50, 0.2));
        }

        [Test]
        public void ThrowsArgumentExceptionIfFuelAmountIsMoreThanTankCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("Golf", 60, 65, 0.2));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowsArgumentExceptionIfFuelConsumptionPerKmIsLowerOrEqualTo0(double consumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Golf", 60, 50, consumption));
        }

        [Test]
        public void DriveMethodShouldReducesFuelAmount()
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
        public void DriveMethodShouldThrowInvalidException()
        {
            Car car = new Car("Golf", 60, 50, 0.2);

            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        [Test]
        public void RefuelMethodShouldMultiplyTotalFuelAmount()
        {
            Car car = new Car("Golf", 60, 50, 0.2);
            car.Refuel(10);

            double fuel = car.FuelAmount;
            double expectedFuel = 60;

            Assert.AreEqual(expectedFuel, fuel);
        }

        [Test]
        public void RefuelMethodShouldThrowException()
        {
            Car car = new Car("Golf", 60, 50, 0.2);

            Assert.Throws<InvalidOperationException>(() => car.Refuel(100));
        }
    }
}