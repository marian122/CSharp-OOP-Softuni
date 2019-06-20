using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5.BorderControl
{
    public class Robot : IIDentify
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }

        public string Id { get; set; }
       
    }
}
