using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PEW.ApplicationServices;
using PEW.Core.Interfaces.ApplicationServices;

namespace PEW.Tests.ApplicationServices
{
    [TestFixture]
    public class HockeyStatsTests
    {
        [Test]
        public void GetStats_should_return_a_list_for_elitserien()
        {
            var service = new HockeyStatsService();
            var stats = service.GetStats(League.ES, StatsCategory.Points);
            Assert.AreEqual(stats.Count(), 25);
        }

        [Test]
        public void GetStats_should_return_a_list_for_goalscorers_elitserien()
        {
            var service = new HockeyStatsService();
            var stats = service.GetStats(League.ES, StatsCategory.Goals);
            Assert.AreEqual(stats.Count(), 25);
        }
    }
}
