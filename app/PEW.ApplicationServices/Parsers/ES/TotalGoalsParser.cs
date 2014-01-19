using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PEW.Core;
using PEW.Core.Domain;
using PEW.Core.Interfaces;

namespace PEW.ApplicationServices.Parsers.ES
{
    public class TotalGoalsParser : AbstractStatsParser, IStatsParser
    {
        public TotalGoalsParser(string url) : base(url)
        {
        }

        public IEnumerable<StatsRow> Execute()
        {
            var i = 1;
            var list = new List<StatsRow> { new StatsRow() };
            foreach (var cell in _nodes)
            {

                var sr = list.Last();
                if (string.IsNullOrEmpty(cell.InnerHtml)) continue;
                var s = Regex.Replace(cell.InnerHtml, ProjectConstants.HtmlTagPattern, string.Empty);

                switch (i % 8)
                {
                    case 1:
                        sr.Rank = Parse(s);
                        break;
                    case 2:
                        sr.Jersey = s;
                        break;
                    case 3:
                        sr.Player = s;
                        break;
                    case 4:
                        sr.Team = s;
                        break;
                    case 5:
                        sr.Position = s;
                        break;
                    case 6:
                        sr.GamesPlayed = Parse(s);
                        break;
                    case 7:
                        sr.Goals = Parse(s);
                        break;
                    case 0:
                        list.Add(new StatsRow());
                        break;
                }

                i++;
            }

            return list.Where(sr => !string.IsNullOrEmpty(sr.Player));
        }
    }
}