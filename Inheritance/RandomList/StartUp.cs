﻿using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList
            {
                "Test",
                "Ivan",
                "Pesho"
            };

            Console.WriteLine(randomList.RandomString());
        }
    }
}
