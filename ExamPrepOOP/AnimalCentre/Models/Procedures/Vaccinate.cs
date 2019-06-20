using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);

            if (animal.IsVaccinated == true)
            {
                throw new ArgumentException($"{animal.Name} is already vaccinated");
            }

            animal.Energy -= 8;
            animal.IsVaccinated = true;

            base.procedureHistory.Add(animal);
        }
    }
}
