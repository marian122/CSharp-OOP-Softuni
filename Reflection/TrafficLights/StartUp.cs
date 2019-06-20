using System;
using System.Collections.Generic;
using System.Reflection;

namespace TrafficLights
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            TrafficLight[] trafficLight = new TrafficLight[input.Length];

            for (int i = 0; i < trafficLight.Length; i++)
            {
                trafficLight[i] = (TrafficLight)Activator
                    .CreateInstance(typeof(TrafficLight), new object[] { input[i] });

            }

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var currentLight = new List<string>();

                foreach (var light in trafficLight)
                {
                    light.ChangeLight();

                    var field = typeof(TrafficLight)
                        .GetField("lights", BindingFlags.Instance | BindingFlags.NonPublic);

                    currentLight.Add(field.GetValue(light).ToString());
                }

                Console.WriteLine(string.Join(" ", currentLight));
            }
        }
    }
}
