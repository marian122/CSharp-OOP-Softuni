using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var fuelQuantity = double.Parse(input[1]);
            var fuelConsumptionInLiterPerKm = double.Parse(input[2]);

            Car car = new Car(fuelQuantity, fuelConsumptionInLiterPerKm);

            var secondInput = Console.ReadLine().Split();
            fuelQuantity = double.Parse(secondInput[1]);
            fuelConsumptionInLiterPerKm = double.Parse(secondInput[2]);

            Truck truck = new Truck(fuelQuantity, fuelConsumptionInLiterPerKm);

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var cmdInput = Console.ReadLine().Split();
                string cmd = cmdInput[0];
                string type = cmdInput[1];
                
                if (cmd == "Drive")
                {
                    DriveVehicleCheck(car, truck, cmdInput, type);
                }

                else if (cmd == "Refuel")
                {
                    RefuelVehicleCheck(car, truck, cmdInput, type);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void RefuelVehicleCheck(Car car, Truck truck, string[] cmdInput, string type)
        {
            if (type == "Car")
            {
                double liters = double.Parse(cmdInput[2]);
                car.Refuel(liters);
            }

            else if (type == "Truck")
            {
                double liters = double.Parse(cmdInput[2]);
                truck.Refuel(liters);
            }
        }

        private static void DriveVehicleCheck(Car car, Truck truck, string[] cmdInput, string type)
        {
            if (type == "Car")
            {
                double distance = double.Parse(cmdInput[2]);
                Console.WriteLine(car.Drive(distance));
            }

            else if (type == "Truck")
            {
                double distance = double.Parse(cmdInput[2]);
                Console.WriteLine(truck.Drive(distance));
            }
        }
    }
}
