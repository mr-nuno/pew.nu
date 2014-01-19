using System;

namespace PEW.Core.Domain
{
    public class StatsRow
    {
        public string Player { get; set; }
        public int Rank { get; set; }
        public string Jersey { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int TotalPoints 
        {
            get { return Goals + Assists; }
        }

        public decimal AveragePerGame
        {
            get { return GamesPlayed != 0 ? Math.Round((decimal)(TotalPoints/GamesPlayed), MidpointRounding.AwayFromZero) : 0m; }
        }
    }
}
