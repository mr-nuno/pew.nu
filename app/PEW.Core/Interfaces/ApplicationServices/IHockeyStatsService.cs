using System.Collections.Generic;
using PEW.Core.Domain;

namespace PEW.Core.Interfaces.ApplicationServices
{
    /// <summary>
    /// Enum for leauges
    /// </summary>
    public enum League
    {
        NHL, ES
    }

    /// <summary>
    /// Enum for the stats type.
    /// </summary>
    public enum StatsCategory
    {
        Points, Goals, Assists
    }

    /// <summary>
    /// Interface for getting hockey stats.
    /// </summary>
    public interface IHockeyStatsService
    {
        /// <summary>
        /// Get stats for a specific league and stats category
        /// </summary>
        /// <param name="league"></param>
        /// <param name="statsCategory"></param>
        IEnumerable<StatsRow> GetStats(League league, StatsCategory statsCategory);
    }
}