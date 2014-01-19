using System;
using System.Collections.Generic;
using PEW.ApplicationServices.Parsers.ES;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;

namespace PEW.ApplicationServices
{
    public class HockeyStatsService : IHockeyStatsService
    {

        public IEnumerable<StatsRow> GetStats(League league, StatsCategory statsCategory)
        {
            switch (league)
            {
                case League.NHL:

                    switch (statsCategory)
                    {
                        case StatsCategory.Points:
                            throw new NotImplementedException();
                        case StatsCategory.Goals:
                            throw new NotImplementedException();
                        case StatsCategory.Assists:
                            throw new NotImplementedException();
                        default:
                            throw new ArgumentOutOfRangeException("statsCategory");
                    }


                case League.ES:

                    switch (statsCategory)
                    {
                        case StatsCategory.Points:
                            const string u1 = "http://stats.swehockey.se/Players/Statistics/ScoringLeaders/2892";
                            return new TotalPointsParser(u1).Execute();   
                        case StatsCategory.Goals:
                            const string u2 = "http://stats.swehockey.se/Players/Statistics/GoalScoringLeaders/2892";
                            return new TotalGoalsParser(u2).Execute(); 
                        case StatsCategory.Assists:
                            throw new NotImplementedException();
                        default:
                            throw new ArgumentOutOfRangeException("statsCategory");
                    }

                default:
                    throw new ArgumentOutOfRangeException("league");
            }
        }
    }
}
