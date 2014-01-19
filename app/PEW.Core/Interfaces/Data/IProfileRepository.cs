using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEW.Core.Domain;

namespace PEW.Core.Interfaces.Data
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Profile GetByGamerTag(string gamerTag);
    }
}
