using System;
using System.Collections.Generic;
using System.Text;

namespace Mordor_sCruelPlan
{
    public class FoodFactory
    {
        private const int happiness = 0;

        private int cram = 2;
        private int lembas = 3;
        private int apple = 1;
        private int melon = 1;
        private int honeyCake = 5;
        private int mushrooms = -10;
        private int everythingElse = -1;

        public int Cram { get => cram; set => cram = value; }
        public int Lembas { get => lembas; set => lembas = value; }
        public int Apple { get => apple; set => apple = value; }
        public int Melon { get => melon; set => melon = value; }
        public int HoneyCake { get => honeyCake; set => honeyCake = value; }
        public int Mushrooms { get => mushrooms; set => mushrooms = value; }
        public int EverythingElse { get => everythingElse; set => everythingElse = value; }
    }
}
