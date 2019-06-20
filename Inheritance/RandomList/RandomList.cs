using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            string element = null;
            if (this.Count > 0)
            {

                int index = random.Next(0, this.Count);
                element = this[index];
                this.RemoveAt(index);
            }
            return element;
        }
    }
}
