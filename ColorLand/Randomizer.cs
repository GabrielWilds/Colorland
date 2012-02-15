using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColorLand
{
    public static class Randomizer
    {
        private static Random _random = new Random();
        private static GameColors[] _colors = (GameColors[])Enum.GetValues(typeof(GameColors));
        private static int _seed;

        public static int Seed
        {
            get { return _seed; }
            private set { _seed = value; _random = new Random(value); }
        }

        public static T PickRandomItem<T>(this T[] items)
        {
            return items[_random.Next(0, items.Length)];
        }

        public static int GetRandomNumber()
        {
            return _random.Next();
        }
        public static int GetRandomNumber(int max)
        {
            return _random.Next(max);
        }
        public static int GetRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static GameColors GetRandomColor()
        {    
            return _colors.PickRandomItem<GameColors>();
        }

        public static void SetSeed(int seed)
        {
            Seed = seed;
        }

        public static void RandomizeSeed()
        {
            _random = new Random();
        }
    }
}
