using System;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().Split();
            var fuelQuantity = double.Parse(input[1]);
            var fuelConsumptionInLiterPerKm = double.Parse(input[2]);
            var tankCapacity = double.Parse(input[3]);

            Car car = new Car(fuelQuantity, fuelConsumptionInLiterPerKm, tankCapacity);

            var secondInput = Console.ReadLine().Split();
            fuelQuantity = double.Parse(secondInput[1]);
            fuelConsumptionInLiterPerKm = double.Parse(secondInput[2]);
            tankCapacity = double.Parse(secondInput[3]);

            Truck truck = new Truck(fuelQuantity, fuelConsumptionInLiterPerKm, tankCapacity);

            var thirdInput = Console.ReadLine().Split();
            fuelQuantity = double.Parse(thirdInput[1]);
            fuelConsumptionInLiterPerKm = double.Parse(thirdInput[2]);
            tankCapacity = double.Parse(thirdInput[3]);

            Bus bus = new Bus(fuelQuantity, fuelConsumptionInLiterPerKm, tankCapacity);

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdInput = Console.ReadLine().Split();
                    string cmd = cmdInput[0];
                    string type = cmdInput[1];

                    if (cmd == "Drive")
                    {
                        DriveVehicleCheck(bus, car, truck, cmdInput, type);
                    }
                    else if (cmd == "DriveEmpty")
                    {
                        DriveVehicleCheck(bus, car, truck, cmdInput, type);

                    }
                    else if (cmd == "Refuel")
                    {
                        RefuelVehicleCheck(bus, car, truck, cmdInput, type);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void RefuelVehicleCheck(Bus bus, Car car, Truck truck, string[] cmdInput, string type)
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

            else if (type == "Bus")
            {
                double liters = double.Parse(cmdInput[2]);
                bus.Refuel(liters);
            }
        }

        private static void DriveVehicleCheck(Bus bus, Car car, Truck truck, string[] cmdInput, string type)
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

            else if (type == "Bus")
            {
                if (cmdInput[0] == "DriveEmpty")
                {
                    double emptyDistance = double.Parse(cmdInput[2]);
                    Console.WriteLine(bus.DriveEmpty(emptyDistance));
                }

                else if (cmdInput[0] == "Drive")
                {
                    double distance = double.Parse(cmdInput[2]);
                    Console.WriteLine(bus.Drive(distance));
                }
            }
        }
    }
}
