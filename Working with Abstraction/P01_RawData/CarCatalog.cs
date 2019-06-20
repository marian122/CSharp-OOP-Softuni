using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class CarCatalog
    {
        private List<Car> cars;

        public CarCatalog()
        {
            this.cars = new List<Car>();
        }

        public void Add(string[] parameters)
        {
            var model = parameters[0];
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];


            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tires = new Tire[4];

            int tireIndex = 0;

            for (int j = 5; j <= 12; j += 2)
            {
                var tirePressure = double.Parse(parameters[j]);
                var tireAge = int.Parse(parameters[j + 1]);

                Tire tire = new Tire(tirePressure, tireAge);

                tires[tireIndex] = tire;

                tireIndex++;
            }
            Car car = new Car(model, engine, cargo, tires);

            cars.Add(car);

        }

        public List<Car> GetCar => this.cars;
    }
}
