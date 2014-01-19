using System.Collections.Generic;
using PEW.Core.Domain;

namespace PEW.Core.Interfaces
{
    public interface IStatsParser
    {
        IEnumerable<StatsRow> Execute();
    }
}