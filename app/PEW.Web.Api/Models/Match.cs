using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEW.Web.Api.Models
{
    public class Match
    {
        public string Date { get; set; }
        public string MyTeam { get; set; }
        public string FinalScore { get; set; }
        public string OpposingTeam { get; set; }
        public string OpposingPlayer { get; set; }
        public bool IsWon { get; set; }
        public string Label
        {
            get { return string.Format("{0} vs. {1} {2}", MyTeam, OpposingTeam, FinalScore); }
            set { }
        }
        public int GoalsFor
        {
            get { return ParseFinalScore().For; }
            set { }
        }
        public int GoalsAgainst
        {
            get { return ParseFinalScore().Against; }
            set { }
        }

        public dynamic ParseFinalScore()
        {
            if (string.IsNullOrEmpty(FinalScore)) return new { For = 0, Against = 0 };
            if (FinalScore.IndexOf("-") == -1) return new { For = 0, Against = 0 };
            var s = FinalScore.Trim();
            var goalsFor = s.Substring(0, s.IndexOf("-"));
            var goalsAgainst = s.Substring(s.IndexOf("-") + 1);

            var a = 0;
            var b = 0;

            if (!Int32.TryParse(goalsFor, out a))
            {
                return new { For = 0, Against = 0 };
            }

            if (!Int32.TryParse(goalsAgainst, out b))
            {
                return new { For = 0, Against = 0 };
            }

            return new { For = a, Against = b };

        }
    }
}