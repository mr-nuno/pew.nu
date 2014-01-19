using System.Collections.Generic;
using System.Linq;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Core.Interfaces.Data;

namespace PEW.Handlers
{
    public class GetStatsByGamerTag
    {
        private readonly IEAStatisticsService _statisticsService;

        public GetStatsByGamerTag(IEAStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public IEnumerable<NHLStatistics> Execute(IEnumerable<string> gamerTags, string game, string platform, bool includeHistory = false)
        {
            return gamerTags.Select(gt => Execute(gt, game, platform, includeHistory));
        }

        public NHLStatistics Execute(string gamerTag, string game, string platform, bool includeHistory = false)
        {
            var stats = _statisticsService.FetchHockeyStats(gamerTag, game, platform);
            if (includeHistory) stats.MatchHistory = _statisticsService.FetchMatchHistory(gamerTag, game, 5);
            return stats;
        }
    }
}
