using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Core.Domain
{
    public enum Result
    {
        Win,
        Loss,
        Tie
    };

    public class MatchHistory
    {
        public MatchHistory(IEnumerable<HistoryItem> history, string gamerTag)
        {
            GamerTag = gamerTag;
            History = CreateHistory(history);
            LatestGames = ExtractLatestGamesFromHistory(history);
        }

        public string GamerTag { get; set; }
        public IEnumerable<HistoryItem> History { get; set; }
        public LatestGamesInfo LatestGames { get; set; }

        private IEnumerable<HistoryItem> CreateHistory(IEnumerable<HistoryItem> history) 
        {
            return history == null || history.Count() == 0 ? new List<HistoryItem>() : history.Select(h => new HistoryItem(h.Date, h.MyTeam, h.FinalScore, h.OpposingTeam, h.OpposingPlayer, CheckGameIsWon(h.FinalScore), h.MyTeamId, h.OpposingTeamId));
        }

        private static bool CheckGameIsWon(string finalScore)
        {
            return IsWonGame(finalScore) == Result.Win;
        }

        private static LatestGamesInfo ExtractLatestGamesFromHistory(IEnumerable<HistoryItem> history)
        {
            var wins = 0;
            var losses = 0;
            var ties = 0;
            var currentStreak = 1;
            var streak = new List<Result>();

            foreach (var historyItem in history)
            {
                var iwg = IsWonGame(historyItem.FinalScore);
                streak.Add(iwg);

                switch (iwg)
                {
                    case Result.Win:
                        wins++;
                        break;
                    case Result.Loss:
                        losses++;
                        break;
                    case Result.Tie:
                        ties++;
                        break;
                }
            }

            var isLoosingStreak = false;
            for (var i = 0; i < streak.Count; i++)
            {
                if (i == 0) continue;
                if (streak[i] == Result.Win && streak[i - 1] == Result.Win)
                {
                    currentStreak++;
                    isLoosingStreak = false;
                }
                else if (streak[i] == Result.Loss && streak[i - 1] == Result.Loss)
                {
                    currentStreak++;
                    isLoosingStreak = true;
                }
                else {
                    isLoosingStreak = streak[i - 1] == Result.Loss;
                    break;
                };
            }

            if (isLoosingStreak) currentStreak = currentStreak * -1;

            return LatestGamesInfo.Create(wins, ties, losses, currentStreak);
        }

        private static Result IsWonGame(string result)
        {
            var res = result.Trim();
            var their = res.Substring(res.IndexOf("-") + 1);
            var my = res.Substring(0, res.IndexOf("-"));

            if (int.Parse(my) > int.Parse(their)) return Result.Win;
            return int.Parse(my) == int.Parse(their) ? Result.Tie : Result.Loss;
        }

    }
}
