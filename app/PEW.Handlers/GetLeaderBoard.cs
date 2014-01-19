using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;

namespace PEW.Handlers
{
    public class GetLeaderBoard
    {
        private readonly IEAStatisticsService _statisticsService;

        public GetLeaderBoard(IEAStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public LeaderBoard Execute(string gamerTag, string game, string platform, int count)
        {
            return _statisticsService.FetchLeaderBoard(gamerTag, count + 1, game, platform);
        }
    }
}
