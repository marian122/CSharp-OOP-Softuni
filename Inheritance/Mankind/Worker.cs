using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursInDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursInDay)
            :base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursInDay = workHoursInDay;
        }

        private decimal WeekSalary
        {
            get => this.weekSalary;

            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }
        private decimal WorkHoursInDay
        {
            get => this.workHoursInDay;

            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursInDay = value;
            }
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName}" + Environment.NewLine +
                $"Last Name: {this.LastName}" + Environment.NewLine +
                $"Week Salary: {this.WeekSalary:F2}" + Environment.NewLine +
                $"Hours per day: {this.WorkHoursInDay:F2}" + Environment.NewLine +
                $"Salary per hour: {this.WeekSalary / (this.WorkHoursInDay  * 5):F2}";
        }
    }
}
