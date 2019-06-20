using DungeonsAndCodeWizards.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly DungeonMaster dungeonMaster;

        public IWriter Writer => writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = this.reader.ReadLine();
                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    this.Writer.WriteLine("Parameter Error: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.Writer.WriteLine("Invalid Operation: " + e.Message);
                }

                if (this.dungeonMaster.IsGameOver() || this.isRunning == false)
                {
                    this.Writer.WriteLine("Final stats:");
                    this.Writer.WriteLine(this.dungeonMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "JoinParty":
                    output = this.dungeonMaster.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = this.dungeonMaster.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = this.dungeonMaster.PickUpItem(args);
                    break;
                case "UseItem":
                    output = this.dungeonMaster.UseItem(args);
                    break;
                case "GiveCharacterItem":
                    output = this.dungeonMaster.GiveCharacterItem(args);
                    break;
                case "UseItemOn":
                    output = this.dungeonMaster.UseItemOn(args);
                    break;
                case "GetStats":
                    output = this.dungeonMaster.GetStats();
                    break;
                case "Attack":
                    output = this.dungeonMaster.Attack(args);
                    break;
                case "Heal":
                    output = this.dungeonMaster.Heal(args);
                    break;
                case "EndTurn":
                    output = this.dungeonMaster.EndTurn(args);
                    break;
            }

            if (output != string.Empty)
            {
                this.Writer.WriteLine(output);
            }
        }
    }
}
