using System;
using System.Collections.Generic;
using System.Text;

namespace Problem6.BirthdayCelebrations
{
    public class Pet : IIDentify
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        
        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}
