using StorageMaster.Core.Factories;
using StorageMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private readonly Dictionary<string, Storage> storage;
        private readonly Dictionary<string, Stack<Product>> products;

        private readonly ProductFactory productFactory;
        private readonly StorageFactory storageFactory;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.products = new Dictionary<string, Stack<Product>>();
            this.storage = new Dictionary<string, Storage>();

            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            if (!this.products.ContainsKey(type))
            {
                this.products[type] = new Stack<Product>();
            }

            var product = this.productFactory.CreateProduct(type, price);

            this.products[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);
            this.storage[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var currentStorage = this.storage[storageName];
            var vehicle = currentStorage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int counter = 0;
            foreach (var product in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.products.ContainsKey(product)
                    || this.products[product].Count == 0)
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }

                var currentProduct = this.products[product].Pop();

                this.currentVehicle.LoadProduct(currentProduct);
                counter++;
            }

            return $"Loaded {counter}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storage.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!this.storage.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var sourceStorage = this.storage[sourceName];
            var destinationStorage = this.storage[destinationName];

            var sendTo = sourceStorage.GetVehicle(sourceGarageSlot);
            var destGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {currentVehicle.GetType().Name} to {destinationStorage.Name} (slot {destGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var currentStorage = this.storage[storageName];
            var vehicle = currentStorage.GetVehicle(garageSlot);

            var productsInVehicle = currentVehicle.Trunk.Count();
            var unloadedProductsCount = currentStorage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {currentStorage.Name}";

        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storage[storageName];

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            var sortedStorage = this.storage.Values
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToArray();

            foreach (var storage in sortedStorage)
            {
                sb.AppendLine($"{storage.Name}:");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }

    }
}
