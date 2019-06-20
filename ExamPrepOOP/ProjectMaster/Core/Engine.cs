using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private readonly StorageMaster storage;

        public Engine()
        {
            this.storage = new StorageMaster();
        }

        public void Run()
        {

            while (true)
            {
                var command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    break;
                }

                try
                {
                    var output = InitialCommands(command);
                    Console.WriteLine(output);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }

            var summary = this.storage.GetSummary();
            Console.WriteLine(summary);

        }

        private string InitialCommands(string[] command)
        {
            var output = string.Empty;
            switch (command[0])
            {
                case "AddProduct":
                    {
                        var name = command[1];
                        var price = double.Parse(command[2]);
                        output = this.storage.AddProduct(name, price);
                        break;
                    }
                case "RegisterStorage":
                    {
                        var type = command[1];
                        var name = command[2];
                        output = this.storage.RegisterStorage(type, name);
                        break;
                    }

                case "SelectVehicle":
                    {
                        var storageName = command[1];
                        var garageSlot = int.Parse(command[2]);
                        output = this.storage.SelectVehicle(storageName, garageSlot);
                        break;
                    }

                case "LoadVehicle":
                    {
                        var storageName = command.Skip(1).ToArray();
                        output = this.storage.LoadVehicle(storageName);
                        break;
                    }

                case "SendVehicleTo":
                    {
                        var sourceName = command[1];
                        var sourceGarageSlot = int.Parse(command[2]);
                        var destinationName = command[3];
                        output = this.storage.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                        break;
                    }

                case "UnloadVehicle":
                    {
                        var storageName = command[1];
                        var garageSlot = int.Parse(command[2]);
                        output = this.storage.UnloadVehicle(storageName, garageSlot);
                        break;
                    }

                case "GetStorageStatus":
                    {
                        var storageName = command[1];
                        output = this.storage.GetStorageStatus(storageName);
                        break;
                    }
            }

            return output;
        }
    }
}
