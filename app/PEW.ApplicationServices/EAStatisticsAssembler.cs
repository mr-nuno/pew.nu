using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PEW.Core.Domain;

namespace PEW.ApplicationServices
{
	public class EAStatisticsAssembler
	{
		public static NHLStatistics CreateStats(List<StatisticItem> stats, string id)
		{
			return new NHLStatistics
			{
                GamerTag = id,
                DidNotFinish = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "dnfpercent").FirstOrDefault()),
				Wins = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "wins").FirstOrDefault()),
                Losses = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "losses").FirstOrDefault()),
                CurrentStreak = stats != null && stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "streak").FirstOrDefault()),
                OvertimeLosses = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "ties").FirstOrDefault()),
                GamesPlayed = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "gp").FirstOrDefault()),
                TotalGoalsFor = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "gf").FirstOrDefault()),
                TotalGoalsAgainst = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "ga").FirstOrDefault()),
                AverageGoalsFor = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "agf").FirstOrDefault()),
                AverageGoalsAgainst = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "aga").FirstOrDefault()),
                PenaltyMinutes = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "pim").FirstOrDefault()),
                PenaltyKillPecentage = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "pk").FirstOrDefault()),
                PowerPlayGoalsFor = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "ppg").FirstOrDefault()),
                PowerPlayGoalsAgainst = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "ppga").FirstOrDefault()),
                PowerPlayOpportunities = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "ppo").FirstOrDefault()),
                PowerPlayPercent = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "pp").FirstOrDefault()),
                ShootingPercentage = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "shtp").FirstOrDefault()),
                ShotsAgainstPerGame = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "shotsapg").FirstOrDefault()),
                AverageTimeOnAttack = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "atoa").FirstOrDefault()),
                FaceOffPercentage = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "fop").FirstOrDefault()),
                ShortHandedGoalsFor = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "shg").FirstOrDefault()),
                ShortHandedGoalsAgainst = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "shga").FirstOrDefault()),
                TimesShortHanded = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "tsh").FirstOrDefault()),
                ShotsPerGame = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "shtpg").FirstOrDefault()),
				AverageWinMargin = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "awm").FirstOrDefault()),
				AverageLossMargin = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "alm").FirstOrDefault()),
				FaceOffsWon = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "fo").FirstOrDefault()),
				FaceOffsLost = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "fol").FirstOrDefault()),
				BreakAwayGoals = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "bag").FirstOrDefault()),
				BreakAwayPercentage = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "bap").FirstOrDefault()),
				OneTimerGoals = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "otg").FirstOrDefault()),
				OneTimerPercentage = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "otp").FirstOrDefault()),
				PassAttemptsPerGame = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "papg").FirstOrDefault()),
				PassingPecentage = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "passp").FirstOrDefault()),
				PenaltyShotGoals = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "psg").FirstOrDefault()),
				PenaltyShotAttempts = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "psa").FirstOrDefault()),
				BlockedShots = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "bs").FirstOrDefault()),
				ShutOuts = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "so").FirstOrDefault()),
				TotalPoints = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Label.ToLower() == "overall points").FirstOrDefault()),
				TotalNumberOfHits = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "hits").FirstOrDefault()),
                AverageNumberOfHits = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "hitspg").FirstOrDefault()),
                AveragePenaltyMinutes = stats == null || stats.Count == 0 ? 0 : CreateStatsItem(stats.Where(s => s.Name.ToLower() == "pimpg").FirstOrDefault()),
			};
		}

        public static MatchHistory CreateMatchHistory(IEnumerable<HistoryItem> history, string gamerTag) 
        {
            return new MatchHistory(history, gamerTag);
        }

		private static decimal CreateStatsItem(StatisticItem htmlItem)
		{
			if (htmlItem == null) return 0;
            return decimal.Parse(htmlItem.Value.Trim().Replace(':', '.'), CultureInfo.InvariantCulture);
		}

	}
}
