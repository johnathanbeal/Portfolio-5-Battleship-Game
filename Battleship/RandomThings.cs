using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class RandomThings
    {
        public static string String(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public static int NotMaxHits()
        {
            Random random = new Random();
            int[] numbers = { -1, 0, 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            List<int> not5 = new List<int>(numbers);
            int index = random.Next(not5.Count);
            return not5[index];

        }

        public static int TurnCountOrLess()
        {
            Random random = new Random();
            var lessThan8 = random.Next(-1, 8);
            return lessThan8;
        }
    }
}
