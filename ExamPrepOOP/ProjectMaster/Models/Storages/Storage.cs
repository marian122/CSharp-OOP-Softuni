using StorageMaster.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models
{
    public abstract class Storage : IStorageable
    {
        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[garageSlots];
            this.products = new List<Product>();

            this.FillGarageWithInitialVehicles(vehicles);
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.Products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
        
        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            var freeVehicle = this.garage[garageSlot];

            if (freeVehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }


            return freeVehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var currentVehicle = this.GetVehicle(garageSlot);

            int foundFreeSlot = AddVehicleToFreeGarageSlot(currentVehicle);

            return foundFreeSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var currentVehicle = this.GetVehicle(garageSlot);
            var unpackedProducts = 0;

            while (!this.IsFull && !currentVehicle.IsEmpty)
            {
                Product products = currentVehicle.Unload();
                this.products.Add(products);
                unpackedProducts++;
            }

            return unpackedProducts;
        }

        private int AddVehicleToFreeGarageSlot(Vehicle currentVehicle)
        {

            var freeSlotIndex = Array.IndexOf(this.garage, null);

            if (freeSlotIndex == -1)
            {
                throw new InvalidOperationException("No room in garage!");

            }
            this.garage[freeSlotIndex] = currentVehicle;

            return freeSlotIndex;
        }

        private void FillGarageWithInitialVehicles(IEnumerable<Vehicle> vehicles)
        {
            var index = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                this.garage[index] = vehicle;
                index++;
            }
        }

    }
}
