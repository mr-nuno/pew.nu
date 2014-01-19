using System.Collections.Generic;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;

namespace PEW.Handlers
{
    public class GetTotalPointsForLeague
    {
        private readonly IHockeyStatsService _hockeyStatsService;

        public GetTotalPointsForLeague(IHockeyStatsService hockeyStatsService)
        {
            _hockeyStatsService = hockeyStatsService;
        }

        public IEnumerable<StatsRow> Execute(League league)
        {
            return _hockeyStatsService.GetStats(league, StatsCategory.Points);
        }
    }
}