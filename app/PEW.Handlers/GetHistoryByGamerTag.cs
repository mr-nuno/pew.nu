using System.Collections.Generic;
using System.Linq;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Core.Interfaces.Data;

namespace PEW.Handlers
{
    public class GetHistoryByGamerTag
    {
        private readonly IEAStatisticsService _statisticsService;

        public GetHistoryByGamerTag(IEAStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public IEnumerable<MatchHistory> Execute(IEnumerable<string> gamerTags, string game, string platform, int count)
        {
            return gamerTags.Select(gt => Execute(gt, game, platform, count));
        }

        public MatchHistory Execute(string gamerTag, string game, string platform, int count)
        {
            return _statisticsService.FetchMatchHistory(gamerTag, game, count, platform);
        }

    }
}
