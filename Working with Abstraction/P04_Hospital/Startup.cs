using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital 
{
    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = DictionariesFilling(doctors, departments);

            command = PrintingOnConsole(doctors, departments);
        }

        private static string PrintingOnConsole(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] arguments = command.Split();

                if (arguments.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[arguments[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (arguments.Length == 2 && int.TryParse(arguments[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departments[arguments[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[arguments[0] + arguments[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }

            return command;
        }

        private static string DictionariesFilling(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var doctorName = firstName + secondName;

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[doctorName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                FreeRoomsFilling(doctors, departments, departament, patient, doctorName);

                command = Console.ReadLine();
            }

            return command;
        }

        private static void FreeRoomsFilling(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string doctorName)
        {
            bool freeRooms = departments[departament].SelectMany(x => x).Count() < 60;
            if (freeRooms)
            {
                int room = 0;

                doctors[doctorName].Add(patient);

                for (int rooms = 0; rooms < departments[departament].Count; rooms++)
                {
                    if (departments[departament][rooms].Count < 3)
                    {
                        room = rooms;
                        break;
                    }
                }

                departments[departament][room].Add(patient);
            }
        }
    }
}
