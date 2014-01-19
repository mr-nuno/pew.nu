namespace PEW.Web.Api.Models
{
    public class HockeyStats
    {
        public string Player { get; set; }
        public int Rank { get; set; }
        public string Jersey { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int TotalPoints { get; set; }
        public decimal AveragePerGame { get; set; }
    }
}