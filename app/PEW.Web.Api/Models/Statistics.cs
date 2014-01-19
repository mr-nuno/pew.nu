using System.Collections.Generic;
using PEW.Core.Domain;

namespace PEW.Web.Api.Models
{
    public class Statistics
    {
        public string Console { get; set; }
        public string Level { get; set; }
        public string GamerTag { get; set; }
        public string TotalPoints { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string OvertimeLosses { get; set; }
        public string DidNotFinish { get; set; }
        public string TotalGoalsFor { get; set; }
        public string TotalGoalsAgainst { get; set; }
        public string AverageGoalsFor { get; set; }
        public string AverageGoalsAgainst { get; set; }
        public string TotalNumberOfHits { get; set; }
        public string PenaltyMinutes { get; set; }
        public string CurrentStreak { get; set; }
        public string LongestStreak { get; set; }
        public string PowerPlayGoalsFor { get; set; }
        public string PowerPlayGoalsAgainst { get; set; }
        public string PowerPlayOpportunities { get; set; }
        public string ShortHandedGoalsFor { get; set; }
        public string ShortHandedGoalsAgainst { get; set; }
        public string PenaltyKillPecentage { get; set; }
        public string TimesShortHanded { get; set; }
        public string ShotsPerGame { get; set; }
        public string AverageWinMargin { get; set; }
        public string AverageLossMargin { get; set; }
        public string FaceOffsWon { get; set; }
        public string FaceOffsLost { get; set; }
        public string BreakAwayGoals { get; set; }
        public string BreakAwayPercentage { get; set; }
        public string OneTimerGoals { get; set; }
        public string OneTimerPercentage { get; set; }
        public string ShortHandedOpportunities { get; set; }
        public string PassAttemptsPerGame { get; set; }
        public string PassingPecentage { get; set; }
        public string PenaltyShotGoals { get; set; }
        public string PenaltyShotAttempts { get; set; }
        public string BlockedShots { get; set; }
        public string ShutOuts { get; set; }
        public string GamesPlayed { get; set; }
        public string PowerPlayPercent { get; set; }
        public string ShootingPercentage { get; set; }
        public string FaceOffPercentage { get; set; }
        public bool IsEmpty { get; set; }
        public string AverageNumberOfHits { get; set; }
        public string AveragePenaltyMinutes { get; set; }
        public string ShotsAgainstPerGame { get; set; }
        public string AverageTimeOnAttack { get; set; }
        public string NumberOfGamesForfeited { get; set; }
        public string WinPercent { get; set; }
        public string LossPercent { get; set; }
        public string OvertimeLossPercent { get; set; }
        public string PenaltyShotPercent { get; set; }
        public string OneTimerTotalShots { get; set; }
        public string TotalShots { get; set; }
        public string TotalFaceOffs { get; set; }
        public string TotalTimeOnAttack { get; set; }
        public string BreakAwayOpportunities { get; set; }
        public string TotalTimeInPenaltyBox { get; set; }
        public string TotalTimeInOffensiveZone { get; set; }
        public string TotalShotsAgainst { get; set; }
        public string TotalShotsAgainstPercent { get; set; }
        public IEnumerable<Match> History { get; set; }
    }
}