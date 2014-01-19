using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Core.Domain
{
    /*public class LeaderBoard
    {
        public IEnumerable<LeaderBoardItem> Items { get; set; }
    }*/

    public class LeaderBoard
    {
        private IEnumerable<LeaderBoardItem> _items;

        public LeaderBoardItem Mine 
        {
            get { return _items.Any() ? _items.Last() : null; }
            set { }
        }
        
        public IEnumerable<LeaderBoardItem> Items 
        { 
            get 
            {
                var count = _items.Count() - 1;
                return _items.Any() ? _items.Take(count) : Enumerable.Empty<LeaderBoardItem>(); 
            }
            set { _items = value; }
        }
    }

    public class LeaderBoardItem 
    {
        public string GamerTag { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        public int Level { get; set; }
        public int Wins { get; set; }
        public int Ties { get; set; }
        public int Losses { get; set; }
        public int Disqualified { get; set; }
        public int GamesPlayed { get; set; }

        #region Calculated

        public decimal WinPercent
        {
            get { return NHLStatistics.CalculatePercent(Wins, GamesPlayed); }
            set { }
        }

        public decimal LossPercent
        {
            get { return NHLStatistics.CalculatePercent(Losses, GamesPlayed); }
            set { }
        }

        #endregion
    }
}
