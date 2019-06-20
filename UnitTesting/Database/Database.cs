namespace Databasee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int defaultSizeArr = 16;
        private int[] numbers;
        private int index;

        public Database(params int[] collection)
            :this(collection.ToList())
        {
        }

        public Database(IEnumerable<int> collection)
        {
            this.index = 0;
            this.numbers = new int[defaultSizeArr];
            this.Numbers = collection.ToArray();

        }

        public int[] Numbers
        {
            get
            {
                List<int> nums = new List<int>();
                for (int i = 0; i < index; i++)
                {
                    nums.Add(this.numbers[i]);
                }

                return nums.ToArray();
            }

            set
            {
                if (value.Length > defaultSizeArr || value.Length < 1)
                {
                    throw new InvalidOperationException("Invalid collection size.");
                }

                this.numbers = new int[defaultSizeArr];

                for (int i = 0; i < value.Length; i++)
                {
                    this.numbers[this.index] = value[i];
                    this.index++;
                }


            }
        }

        public void Add(int number)
        {
            if (index >= 16)
            {
                throw new InvalidOperationException("Database is full.");
            }

            this.numbers[this.index] = number;
            this.index++;
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Database is empty.");
            }

            this.numbers[this.index - 1] = default(int); //0
            this.index--;

        }

        public void Fetch()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var item = numbers[i];
            }
        }
    }
}
