namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Core.Factory;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MachinesManager : IMachinesManager
    {
        private IDictionary<string, IPilot> pilots;
        private IDictionary<string, IMachine> machines;
        private MachineFactory machineFactory;

        public MachinesManager()
        {
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
            this.machineFactory = new MachineFactory();
        }

        public string HirePilot(string name)
        {

            if (this.pilots.ContainsKey(name))
            {
                return $"Pilot {name} is hired already";
            }


            this.pilots.Add(name, new Pilot(name));
            return $"Pilot {name} hired";


        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {

            if (this.machines.ContainsKey(name))
            {
                return $"Machine {name} is manufactured already";
            }

            this.machines.Add(name, new Tank(name, attackPoints, defensePoints));
            return $"Tank {name} manufactured - attack: {(attackPoints - 40):f2}; defense: {(defensePoints + 30):f2}";

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {

            if (this.machines.ContainsKey(name))
            {
                return $"Machine {name} is manufactured already";
            }

            this.machines.Add(name, new Fighter(name, attackPoints, defensePoints));
            return $"Fighter {name} manufactured - attack: {(attackPoints + 50):f2}; defense: {(defensePoints - 25):f2}; aggressive: ON";

        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            
            var pilot = this.pilots[selectedPilotName];
            var machine = this.machines[selectedMachineName];

            if (!this.pilots.ContainsKey(selectedPilotName))
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            if (!this.machines.ContainsKey(selectedMachineName))
            {
                return $"Machine {selectedMachineName} could not be found";
            }


            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;
            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
       

        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var sb = new StringBuilder();
            var attackingMachine = this.machines[attackingMachineName];
            var defendingMachine = this.machines[defendingMachineName];

            if (!this.machines.ContainsKey(attackingMachineName))
            {
               return $"Machine {attackingMachineName} could not be found";
            }

            if (!this.machines.ContainsKey(defendingMachineName))
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackingMachine.HealthPoints == 0)
            {
                sb.AppendLine($"Dead machine {attackingMachineName} cannot attack or be attacked");
            }

            if (defendingMachine.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";

            }

            attackingMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:f2}";

        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots[pilotReporting];

            return pilot.Report();
                   
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines[machineName];

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {

            if (!this.machines.ContainsKey(fighterName))
            {
                return $"Machine {fighterName} could not be found";
            }

            var findMachine = (Fighter)this.machines[fighterName];
            findMachine.ToggleAggressiveMode();
            return $"Fighter {fighterName} toggled aggressive mode";

        }
      
        public string ToggleTankDefenseMode(string tankName)
        {

            if (!this.machines.ContainsKey(tankName))
            {
                return $"Machine {tankName} could not be found";
            }

            var tankToFind = (Tank)this.machines[tankName];
            tankToFind.ToggleDefenseMode();
            return $"Tank {tankName} toggled defense mode";
        }
    }
}