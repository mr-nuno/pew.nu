using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using PEW.Core;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Handlers;
using PEW.Web.Api.Models;

namespace PEW.Web.Api.Controllers
{
    public class HockeyStatsController : ApiController
    {
        public IEnumerable<HockeyStats> GetTotalPointsLeaderboard(string league)
        {
            if (string.IsNullOrEmpty(league)) throw new ArgumentNullException("League cannot be null");
            if (!league.Equals("es") && !league.Equals("nhl")) throw new ArgumentOutOfRangeException("Invalid league");
            return Mapper.Map<IEnumerable<StatsRow>, IEnumerable<HockeyStats>>(Utilities.Use<GetTotalPointsForLeague>().Execute(league.Equals("es") ? League.ES : League.NHL));
        }
    }
}
