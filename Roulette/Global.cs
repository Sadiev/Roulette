using System;
using System.Collections.Generic;

namespace Roulette
{
    class Global
    {
        public static decimal Blance = 500;
        public static decimal TotalBet = 0;
        public static Color[] BetNumbers = new Color[37];
        public static List<Bet> Bets= new List<Bet>();
        public Global()
        {
            Random random = new Random();
            for (int i = 0; i < BetNumbers.Length; i++)
            {
                Array values = Enum.GetValues(typeof(Color));
                BetNumbers[i] = (Color)values.GetValue(random.Next(values.Length));
            }
        }
    }
}
