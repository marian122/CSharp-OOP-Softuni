using SoftUniRestaurant.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine : IEngine
    {
        private RestaurantController restaurantController;

        public Engine(RestaurantController restaurantController)
        {
            this.restaurantController = restaurantController;
        }

        public void Run()
        {
            var line = Console.ReadLine();

            while (line != "END")
            {
                var input = line.Split();

                try
                {
                    Data(input);
                }
                catch (ArgumentException ex)    
                {
                    Console.WriteLine(ex.Message);
                    
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"{this.restaurantController.GetSummary():f2}");
        }

        private void Data(string[] input)
        {
            var commandType = input[0];
            var type = "";
            var name = "";
            var tableNumber = 0;
            var result = "";

            switch (commandType)
            {
                case "AddFood":
                    type = input[1];
                    name = input[2];
                    var price = decimal.Parse(input[3]);
                    result = restaurantController.AddFood(type, name, price);
                    break;

                case "AddDrink":
                    type = input[1];
                    name = input[2];
                    var servingSize = int.Parse(input[3]);
                    var brand = input[4];
                    result = this.restaurantController.AddDrink(type, name, servingSize, brand);
                    break;

                case "AddTable":
                    type = input[1];
                    tableNumber = int.Parse(input[2]);
                    var capacity = int.Parse(input[3]);
                    result = this.restaurantController.AddTable(type, tableNumber, capacity);
                    break;

                case "ReserveTable":
                    var numberOfPeople = int.Parse(input[1]);
                    result = this.restaurantController.ReserveTable(numberOfPeople);
                    break;

                case "OrderFood":
                    tableNumber = int.Parse(input[1]);
                    var foodName = input[2];
                    result = this.restaurantController.OrderFood(tableNumber, foodName);
                    break;

                case "OrderDrink":
                    tableNumber = int.Parse(input[1]);
                    var drinkName = input[2];
                    var drinkBrand = input[3];
                    result = this.restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand);
                    break;

                case "LeaveTable":
                    tableNumber = int.Parse(input[1]);
                    result = this.restaurantController.LeaveTable(tableNumber);
                    break;

                case "GetFreeTablesInfo":
                    result = this.restaurantController.GetFreeTablesInfo();
                    break;

                case "GetOccupiedTablesInfo":
                    result = this.restaurantController.GetOccupiedTablesInfo();
                    break;

                default:
                    throw new ArgumentException("Invalid command type!");
            }
            Console.WriteLine(result);
        }
    }
}
