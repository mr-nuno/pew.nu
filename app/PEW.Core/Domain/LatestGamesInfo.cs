using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Core.Domain
{
    public class LatestGamesInfo
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int CurrentStreak { get; set; }
        public int Form { get; set; }

        private LatestGamesInfo(int wins, int ties, int losses, int currentStreak)
        {
            Wins = wins;
            Ties = ties;
            Losses = losses;
            CurrentStreak = currentStreak;
            Form = Wins - Losses;
        }

        public static LatestGamesInfo Create(int wins, int ties, int losses, int currentStreak)
        {
            return new LatestGamesInfo(wins, ties, losses, currentStreak);
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Wins, Ties, Losses);
        }
    }
}
