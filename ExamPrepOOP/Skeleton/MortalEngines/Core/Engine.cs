using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            var line = Console.ReadLine();
                var result = "";

            while (line != "Quit")
            {
                var input = line.Split();
                try
                {
                    var cmdType = input[0];
                    
                    switch (cmdType)
                    {
                        case "HirePilot":
                            var name = input[1];
                            result = machinesManager.HirePilot(name);
                            break;
                        case "PilotReport":
                            name = input[1];
                            result = machinesManager.PilotReport(name);
                            break;
                        case "ManufactureTank":
                            name = input[1];
                            var attack = double.Parse(input[2]);
                            var deff = double.Parse(input[3]);
                            result = machinesManager.ManufactureTank(name, attack, deff);
                            break;

                        case "ManufactureFighter":
                            name = input[1];
                            attack = double.Parse(input[2]);
                            deff = double.Parse(input[3]);
                            result = machinesManager.ManufactureFighter(name, attack, deff);
                            break;

                        case "MachineReport":
                            name = input[1];
                            result = machinesManager.MachineReport(name);
                            break;

                        case "AggressiveMode":
                            name = input[1];
                            result = machinesManager.ToggleFighterAggressiveMode(name);
                            break;

                        case "DefenseMode":
                            name = input[1];
                            result = machinesManager.ToggleTankDefenseMode(name);
                            break;

                        case "Engage":
                            name = input[1];
                            var machineName = input[2];
                            result = machinesManager.EngageMachine(name, machineName);
                            break;

                        case "Attack":
                            machineName = input[1];
                            var secondName = input[2];
                            result = machinesManager.AttackMachines(machineName, secondName);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();

            Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
