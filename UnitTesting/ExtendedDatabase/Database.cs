namespace ExtendedDatabase 
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int defaultSizeArr = 16;
        private int[] numbers;
        private int index;
        private People[] data;

        public Database(params People[] data)
        {
            CheckLength(data);
            this.data = new People[16];
            this.index = 0;
            FillingArray(data);

        }

              
        public void Add(People person)
        {
            if (this.index >= 16)
            {
                throw new InvalidOperationException("Data is full.");
            }

            if (this.data.Any(p => p != null && p.Username == person.Username))
            {
                throw new InvalidOperationException("Person with the" +
                    " same username already exists!");
            }

            if (this.data.Any(p => p != null && p.Id == person.Id))
            {
                throw new InvalidOperationException("Person with the" +
                    " same id already exists!");
            }

            this.data[index] = person;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Data is empty.");
            }

            this.data[this.index - 1] = null; //0
            this.index--;

        }

        public People FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username cannot be null or empty!");
            }

            if (!this.data.Any(p => p != null && p.Username == username))
            {
                throw new InvalidOperationException("Person with this " +
                    "id doesn't exist!");
            }

            return this.data.First(p => p != null && p.Username == username);
        }

        public People FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be less than zero.");
            }

            if (!this.data.Any(p => p != null && p.Id == id))
            {
                throw new InvalidOperationException("Person with this " +
                    "id doesn't exist!");
            }

            return this.data.First(p => p != null && p.Id == id);
        }

        public People[] Fetch()
        {
            return this.data.Take(index).ToArray();
        }

        private void FillingArray(People[] data)
        {
            foreach (var person in data)
            {
                this.Add(person);
            }
        }

        private void CheckLength(People[] data)
        {
            if (this.index > 16)
            {
                throw new InvalidOperationException("The size of the " +
                    "parameter must be equal or less than 16!");
            }

        }
    }
}
