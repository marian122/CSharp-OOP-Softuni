using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        private string FacultyNumber
        {
            get => this.facultyNumber;

            set
            {
                if (value.Any(s => !char.IsLetterOrDigit(s)) || value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName}" + Environment.NewLine +
                $"Last Name: {this.LastName}" + Environment.NewLine +
                $"Faculty number: {this.facultyNumber}" + Environment.NewLine;
        }
    }
}
