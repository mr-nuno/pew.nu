using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Core.Domain
{
	/// <summary>
	/// This holds the nhl stats from ea for a specific user.
	/// </summary>
	public class NHLStatistics
	{
		public static NHLStatistics Default
		{
			get { return new NHLStatistics { IsEmpty = true }; }
		}

        public string Console { get; set; }
	    public int Level { get; set; }
        public string GamerTag { get; set; }
		public decimal TotalPoints { get; set; }
		public decimal Wins { get; set; }
		public decimal Losses { get; set; }
		public decimal OvertimeLosses { get; set; }
		public decimal DidNotFinish { get; set; }
		public decimal TotalGoalsFor { get; set; }
		public decimal TotalGoalsAgainst { get; set; }
        public decimal AverageGoalsFor { get; set; }
        public decimal AverageGoalsAgainst { get; set; }
		public decimal TotalNumberOfHits { get; set; }
		public decimal PenaltyMinutes { get; set; }
		public decimal CurrentStreak { get; set; }
		public decimal LongestStreak { get; set; }
		public decimal PowerPlayGoalsFor { get; set; }
		public decimal PowerPlayGoalsAgainst { get; set; }
		public decimal PowerPlayOpportunities { get; set; }
		public decimal ShortHandedGoalsFor { get; set; }
		public decimal ShortHandedGoalsAgainst { get; set; }
		public decimal PenaltyKillPecentage { get; set; }
		public decimal TimesShortHanded { get; set; }
		public decimal ShotsPerGame { get; set; }
		public decimal AverageWinMargin { get; set; }
		public decimal AverageLossMargin { get; set; }
		public decimal FaceOffsWon { get; set; }
		public decimal FaceOffsLost { get; set; }
		public decimal BreakAwayGoals { get; set; }
		public decimal BreakAwayPercentage { get; set; }
		public decimal OneTimerGoals { get; set; }
		public decimal OneTimerPercentage { get; set; }
		public decimal ShortHandedOpportunities { get; set; }
		public decimal PassAttemptsPerGame { get; set; }
		public decimal PassingPecentage { get; set; }
		public decimal PenaltyShotGoals { get; set; }
		public decimal PenaltyShotAttempts { get; set; }
		public decimal BlockedShots { get; set; }
		public decimal ShutOuts { get; set; }
        public decimal GamesPlayed { get; set; }
        public decimal PowerPlayPercent { get; set; }
        public decimal ShootingPercentage { get; set; }
        public decimal FaceOffPercentage { get; set; }
		public bool IsEmpty { get; set; }
        public decimal AverageNumberOfHits { get; set; }
        public decimal AveragePenaltyMinutes { get; set; }
        public decimal ShotsAgainstPerGame { get; set; }
        public decimal AverageTimeOnAttack { get; set; }

        public MatchHistory MatchHistory { get; set; }

	    #region Aggregated

        public decimal NumberOfGamesForfeited
        {
            get { return Math.Round(DidNotFinish != 0 ? GamesPlayed * (DidNotFinish / 100) : 0); }
            set { }
        }

		public decimal WinPercent
		{
			get { return CalculatePercent(Wins, GamesPlayed); }
			set { }
		}

		public decimal LossPercent
		{
			get { return CalculatePercent(Losses, GamesPlayed); }
			set { }
		}

		public decimal OvertimeLossPercent
		{
			get { return CalculatePercent(OvertimeLosses, GamesPlayed); }
			set { }
		}

		public decimal PenaltyShotPercent
		{
			get { return CalculatePercent(PenaltyShotGoals, PenaltyShotAttempts); }
			set { }
		}

		public decimal OneTimerTotalShots
		{
			get { return CalculateTotalFromPercent(OneTimerGoals, OneTimerPercentage); }
			set { }
		}

		public decimal TotalShots
		{
			get { return Math.Round(ShotsPerGame * GamesPlayed, 0); }
			set { }
		}

		public decimal TotalFaceOffs
		{
			get { return FaceOffsLost + FaceOffsWon; }
			set { }
		}

        public decimal TotalTimeOnAttack
        {
            get { return GamesPlayed * AverageTimeOnAttack; }
            set { }
        }

		public decimal BreakAwayOpportunities
		{
			get { return CalculateTotalFromPercent(BreakAwayGoals, BreakAwayPercentage); }
			set { }
		}

	    public decimal TotalShotsAgainst
	    {
            get { return Math.Round(GamesPlayed * ShotsAgainstPerGame, 0); }
	        set { }
	    }

        public decimal TotalShotsAgainstPercent
        {
            get { return TotalShotsAgainst != 0 ? (TotalGoalsAgainst / TotalShotsAgainst) * 100 : 0 ; }
            set { }
        }

	    #endregion

        #region Public helpers

        public static decimal CalculatePercent(decimal number, decimal divider)
        {
            if (divider == 0) return 0;
            return Math.Round(number / divider, 3) * 100;
        }

        #endregion

        #region Private helpers

		private static decimal CalculateTotalFromPercent(decimal number, decimal percent)
		{
			if (percent == 0) return 0;
			return Math.Round(number / (percent / 100));
		}

		private static bool CompareAndConvert(object thisValue, object compareToValue, bool isNegatedParameter)
		{
			decimal val1;
			decimal val2;
			if (decimal.TryParse(thisValue.ToString(), out val1) && decimal.TryParse(compareToValue.ToString(), out val2))
			{
				if (!isNegatedParameter) return val1 > val2;
				return val1 < val2;
			}

			return false;
		}

		private static bool IsNegatedParameter(string paramName)
		{
			switch (paramName)
			{
				case "Losses":
					return true;
				case "OvertimeLosses":
					return true;
				case "LossPercent":
					return true;
				case "OvertimeLossPercent":
					return true;
				case "DidNotFinish":
					return true;
				case "TotalGoalsAgainst":
					return true;
				case "PowerPlayGoalsAgainst":
					return true;
				case "ShortHandedGoalsAgainst":
					return true;
				case "FaceOffsLost":
					return true;
				default:
					return false;
			}
		}

		#endregion

		#region Public methods

		public virtual IDictionary<string, bool> CompareTo(NHLStatistics stats)
		{
			var obj = GetType();
			var compareObj = stats.GetType();
			var dictionary = new Dictionary<string, bool>();

			foreach (var propertyInfo in obj.GetProperties())
			{
				var thisValue = obj.GetProperty(propertyInfo.Name).GetValue(this, null);
				var compareToValue = compareObj.GetProperty(propertyInfo.Name).GetValue(stats, null);

				if (thisValue == null || compareToValue == null) continue;

				dictionary.Add(propertyInfo.Name, CompareAndConvert(thisValue, compareToValue, IsNegatedParameter(propertyInfo.Name)));

			}

			return dictionary;
		}

		#endregion

        
    }
}
