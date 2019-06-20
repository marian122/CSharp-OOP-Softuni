using System;
using System.Collections.Generic;
using System.Text;
using TrafficLights.Enums;

namespace TrafficLights
{
    public class TrafficLight
    {
        private Lights lights;

        public TrafficLight(string lights)
        {
            this.lights = (Lights)Enum.Parse(typeof(Lights), lights);
        }

        public void ChangeLight()
        {
            var previousLight = (int)this.lights;

            this.lights = (Lights)((previousLight + 1) % Enum.GetNames(typeof(Lights)).Length); 
        }
       
    }
}
