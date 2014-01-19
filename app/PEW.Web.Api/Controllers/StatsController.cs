using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using PEW.Core;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Core.Interfaces.Data;
using PEW.Handlers;
using PEW.Web.Api.Models;

namespace PEW.Web.Api.Controllers
{
    public class StatsController : ApiController
    {
        private readonly IEAStatisticsService _statsService;

        public StatsController(IEAStatisticsService statsService)
        {
            _statsService = statsService;
        }

        public bool CheckHasPlayedGame(string gamerTag)
        {
            return false;
        }

        public IEnumerable<Statistics> GetStats(string game, string gamerTag, string platForm, bool? includeHistory)
        {            
            return Mapper.Map<IEnumerable<NHLStatistics>, IEnumerable<Statistics>>(
                Utilities.Use<GetStatsByGamerTag>().Execute(gamerTag.Split(','), game, platForm, includeHistory.HasValue && includeHistory.Value));
        }

        public IEnumerable<MatchHistory> GetHistory(string game, string gamerTag, int? count, string platForm)
        {
            return Utilities.Use<GetHistoryByGamerTag>().Execute(gamerTag.Split(','), game, platForm, count ?? 5);
        }

        public LeaderBoard GetLeaderboard(string game, string gamerTag, int? count, string platForm)
        {
            return Utilities.Use<GetLeaderBoard>().Execute(gamerTag, game, platForm, count ?? 10);
        }

        public int GetLevel(string game, string gamerTag, string platForm)
        {
            return _statsService.FetchLevel(gamerTag, game, platForm);
        }
    }
}
