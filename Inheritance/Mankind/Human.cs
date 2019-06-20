using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;

            set
            {
                if (!char.IsUpper(value, 0))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }

                else if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get => this.lastName;

            set
            {
                if (!char.IsUpper(value, 0))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }

                else if (value.Length <= 2)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: lastName");
                }
                this.lastName = value;

            }
        }

        public override string ToString()
        {
            return $"First name: {this.FirstName}" + Environment.NewLine +
                $"Last name: {this.LastName}";
        }
    }
}
